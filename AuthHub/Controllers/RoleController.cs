using AuthHub.Application.DTOs;
using AuthHub.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService; 
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(RoleDto role)
        {
            var result  = await _roleService.AddAsync(role);    
            return Ok(result);

        }


    }
}
