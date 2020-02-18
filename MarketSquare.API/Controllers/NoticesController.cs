using System;
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
        public NoticesController(INoticeService noticeService)
        {
            _noticeService = noticeService ?? throw new ArgumentNullException(nameof(noticeService));
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
            return Ok(notice);
        }
    }
}