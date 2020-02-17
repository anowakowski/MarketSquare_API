using System;
using System.Threading.Tasks;
using MarketSquare.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketSquare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly INoticeService _noticeService;
        public ListController(INoticeService noticeService)
        {
            _noticeService = noticeService ?? throw new ArgumentNullException(nameof(noticeService));
        }

        [HttpGet("getAllNotices")]
        public async Task<IActionResult> GetAllUsers()
        {
            var notices = await _noticeService.GetNotices();

            return Ok(notices);
        }
    }
}