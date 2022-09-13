using AuthenticationManager.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_rolesService.GetAll());
        }

        [HttpGet("{login}")]
        public async Task<IActionResult> GetUserRoles(string login)
        {
            var userRoles = await _rolesService.GetUserRolesAsync(login);

            if (userRoles == null)
            {
                return NotFound();
            }

            return Ok(userRoles);
        }
    }
}
