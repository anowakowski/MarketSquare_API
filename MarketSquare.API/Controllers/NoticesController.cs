using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> getAllNotices()
        {
            var notices = await _noticeService.GetNoticeTags();

            return Ok(notices);
        }
    }
}