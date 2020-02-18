using System;
using System.Threading.Tasks;
using MarketSquare.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketSquare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ISeedService _seedService;
        public SeedController(ISeedService seedService)
        {
            _seedService = seedService ?? throw new ArgumentNullException(nameof(seedService));
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            await _seedService.Seed();

            return Ok();
        }
    }
}