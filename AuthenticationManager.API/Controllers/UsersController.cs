﻿using AuthenticationManager.Database;
using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.User;
using AuthenticationManager.Interfaces;
using AuthenticationManager.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
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
            bool isEntityFound = await _usersService.DeleteAsync(id);

            if (!isEntityFound)
            {
                return NotFound($"Entity with id: {id} doesn't exist in the database.");
            }

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
