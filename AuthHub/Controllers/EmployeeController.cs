using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("testing done");
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("AdminOnly")]
        public IActionResult AdminOnly()
        {
            return Ok("Admin access granted");
        }
    }
}
