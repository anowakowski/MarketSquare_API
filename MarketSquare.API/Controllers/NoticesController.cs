using System;
using System.Linq;
using System.Threading.Tasks;
using MarketSquare.API.Dtos;
using MarketSquare.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketSquare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticesController : ControllerBase
    {
        private readonly INoticeService _noticeService;
         private readonly ITagService _tagService;
        public NoticesController(
            INoticeService noticeService, 
            ITagService tagService)
        {
            _noticeService = noticeService ?? throw new ArgumentNullException(nameof(noticeService));
            _tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
        }

        [HttpGet("getAllNotices")]
        public async Task<IActionResult> getAllNotices([FromQuery(Name = "tags")] int[] tags)
        {
            var notices = await _noticeService.GetNoticeTags(tags);
            return Ok(notices);
        }

        [HttpPost("addNotice")]
        public async Task<IActionResult> AddNotice(NewNotice notice)
        {
            var tagsToAdd = notice.Tags.Where(t => t.Id == 0);
            foreach(var t in tagsToAdd)
            {
                await _tagService.AddTag(t);
            }
            
            await _noticeService.AddNotice(notice);
            return Ok(notice);
        }


        [HttpGet("getMyNotices")]
        public IActionResult GetMyNotices(string username)
        {
            var notices = _noticeService.GetMyNotices(username);
            return Ok(notices);
        }
    }
}