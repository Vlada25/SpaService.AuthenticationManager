using AuthenticationManager.Database;
using AuthenticationManager.Domain.Configuration;
using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.User;
using AuthenticationManager.Interfaces.Services;
using AuthenticationManager.Interfaces.Services.Person;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthenticationService _authService;
        private readonly IHttpPersonService _httpPersonService;

        public AccountsController(IAuthenticationService authService,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IHttpPersonService httpPersonService)
        {
            _authService = authService;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _httpPersonService = httpPersonService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            if (loginUser == null)
            {
                return BadRequest("LoginUser object sent from client is null.");
            }

            if (!await _authService.ValidateUser(loginUser))
            {
                return Unauthorized("Authentication failed. Wrong user name or password.");
            }

            return Ok(new {Token = await _authService.CreateToken()});
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            var user = _mapper.Map<User>(registerUser);

            foreach (var roleName in registerUser.Roles)
            {
                var roleResult = await _roleManager.RoleExistsAsync(roleName);

                if (!roleResult)
                {
                    return BadRequest($"Role {roleName} is not exist");
                }
            }

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, registerUser.Roles);

            if (registerUser.Roles.Contains("Master"))
            {
                _httpPersonService.CreateMaster(registerUser, Guid.Parse(user.Id));
            }
            else
            {
                _httpPersonService.CreateClient(registerUser, Guid.Parse(user.Id));
            }

            return Ok("Registration completed successfully!");
        }

        [HttpPost("{count}")]
        public async Task<IActionResult> CreateFakeUsers(int count)
        {
            var registerUsers = FakeUsersInitializer.GetFakeUsers(count);
            registerUsers.AddRange(UsersConfig.ConfigNecessaryUsers());

            foreach (var user in registerUsers)
                await Register(user);

            return StatusCode(200);
        }
    }
}
