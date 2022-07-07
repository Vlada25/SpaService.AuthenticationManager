using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.User;
using AuthenticationManager.Interfaces;
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

        public AccountsController(IAuthenticationService authService,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _authService = authService;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
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

            string token = await _authService.CreateToken();

            return Ok(token);
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

            return StatusCode(201);
        }
    }
}
