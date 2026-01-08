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
        [Authorize(Roles = "HR")]
        [HttpGet("HrOnly")]
        public IActionResult HrOnly()
        {
            return Ok("HR access granted");
        }

        [Authorize(Roles = "HR")]
        [HttpGet("Hrtest")]
        public IActionResult Hrtest()
        {
            return Ok("Hr access granted test");
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("AdminOnly")]
        public IActionResult AdminOnly()
        {
            return Ok("Admin access granted");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Admintest")]
        public IActionResult Admintest()
        {
            return Ok("Admin access granted test");
        }

        [Authorize(Roles = "User")]
        [HttpGet("UserOnly")]
        public IActionResult UserOnly()
        {
            return Ok("User access granted");
        }

        [Authorize(Roles = "User")]
        [HttpGet("Usertest")]
        public IActionResult Usertest()
        {
            return Ok("User access granted test");
        }
    }
}
