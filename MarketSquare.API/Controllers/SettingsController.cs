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

        [HttpGet("SubscribeUser")]
        public async Task<IActionResult> SubscribeUser(string username, string subscribedUsername)
        {
            await _settingsService.SubscribeUser(username, subscribedUsername);
            return Ok();
        }

        [HttpGet("UnsubscribeUser")]
        public async Task<IActionResult> UnsubscribeUser(string username, string subscribedUsername)
        {
            await _settingsService.UnsubscribeUser(username, subscribedUsername);
            return Ok();
        }

        [HttpGet("SubscribeTag")]
        public async Task<IActionResult> SubscribeTag(string username, string tag)
        {
            await _settingsService.SubscribeTag(username, tag);
            return Ok();
        }

        [HttpGet("UnsubscribeTag")]
        public async Task<IActionResult> UnsubscribeTag(string username, string tag)
        {
            await _settingsService.UnsubscribeTag(username, tag);
            return Ok();
        }
        
        [HttpGet("BlacklistUser")]
        public async Task<IActionResult> BlacklistUser(string username, string subscribedUsername)
        {
            await _settingsService.BlacklistUser(username, subscribedUsername);
            return Ok();
        }

        [HttpGet("UnblacklistUser")]
        public async Task<IActionResult> UnblacklistUser(string username, string subscribedUsername)
        {
            await _settingsService.UnblacklistUser(username, subscribedUsername);
            return Ok();
        }

        [HttpGet("BlacklistTag")]
        public async Task<IActionResult> BlacklistTag(string username, string tag)
        {
            await _settingsService.BlacklistTag(username, tag);
            return Ok();
        }

        [HttpGet("UnblacklistTag")]
        public async Task<IActionResult> UnblacklistTag(string username, string tag)
        {
            await _settingsService.UnblacklistTag(username, tag);
            return Ok();
        }
    }
}
