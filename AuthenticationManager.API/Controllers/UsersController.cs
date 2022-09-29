﻿using AuthenticationManager.Interfaces.Services;
using AuthenticationManager.Interfaces.Services.Person;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService,
            IRolesService rolesService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _usersService.GetAllAsync());
        }

        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _usersService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with login '{id}' doesn't exist in datebase");
            }

            return Ok(user);
        }

        [HttpGet("ByLogin/{login}")]
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
            var isEntityFound = await _usersService.DeleteAsync(id);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

            return NoContent();
        }
    }
}
