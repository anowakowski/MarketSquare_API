using System;
using System.Linq;
using System.Threading.Tasks;
using MarketSquare.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketSquare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService tagService;

        public TagsController(ITagService tagService)
        {
            this.tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
        }

        [HttpGet("getAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await this.tagService.GetAllTags();

            var tagNames = tags.Select(tag => tag.Name).ToList();

            return Ok(tagNames);
        }
    }
}
