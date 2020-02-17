using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketSquare.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarketSquare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _settingsService;
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService ?? throw new ArgumentNullException(nameof(settingsService));
        }

        [HttpGet("GetBlacklistedTags")]
        public async Task<IActionResult> GetBlacklistedTags(string username)
        {
            var subscriptions = await _settingsService.GetBlacklistedTags(username);
            var tags = subscriptions.Select(u => u.Tag.Name);
            return Ok(tags);
        }

        [HttpGet("GetSubscribedTags")]
        public async Task<IActionResult> GetSubscribedTags(string username)
        {
            var subscriptions = await _settingsService.GetSubscribedTags(username);
            var tags = subscriptions.Select(u => u.Tag.Name);
            return Ok(tags);
        }

        [HttpGet("GetBlacklistedUsers")]
        public async Task<IActionResult> GetBlacklistedUsers(string username)
        {
            var subscriptions = await _settingsService.GetBlacklistedUsers(username);
            var users = subscriptions.Select(u => u.SubscribedUser.Username);
            return Ok(users);
        }

        [HttpGet("GetSubscribedUsers")]
        public async Task<IActionResult> GetSubscribedUsers(string username)
        {
            var subscriptions = await _settingsService.GetSubscribedUsers(username);
            var users = subscriptions.Select(u => u.SubscribedUser.Username);
            return Ok(users);
        }
    }
}
