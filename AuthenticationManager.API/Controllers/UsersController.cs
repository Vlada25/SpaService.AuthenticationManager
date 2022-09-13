using AuthenticationManager.Interfaces.Services;
using AuthenticationManager.Interfaces.Services.Person;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IRolesService _rolesService;
        private readonly IPersonService _httpPersonService;

        public UsersController(IUsersService usersService,
            IRolesService rolesService,
            IPersonService httpPersonService)
        {
            _usersService = usersService;
            _rolesService = rolesService;
            _httpPersonService = httpPersonService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_usersService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _usersService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with login '{id}' doesn't exist in datebase");
            }

            return Ok(user);
        }

        [HttpGet("{login}")]
        public async Task<IActionResult> GetByLogin(string login)
        {
            var user = await _usersService.GetByLoginAsync(login);

            if (user == null)
            {
                return NotFound($"User with login '{login}' doesn't exist in datebase");
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _usersService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            var userRoles = await _rolesService.GetUserRolesAsync(user.UserName);

            if (userRoles.Contains("Master"))
            {
                _httpPersonService.DeleteMaster(id);
            }
            else
            {
                _httpPersonService.DeleteClient(id);
            }

            await _usersService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMasters()
        {
            var users = _usersService.GetAllMastersAsync();

            return Ok(users);
        }
    }
}
