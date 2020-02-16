using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarketSquare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
         [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await GetAllUsers();

            return Ok();
        }
    }
}
