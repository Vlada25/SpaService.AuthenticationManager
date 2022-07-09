using AuthenticationManager.DTO.User;
using AuthenticationManager.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository usersRepository,
            IMapper mapper)
        {
            _repository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _repository.GetAll(trackChanges: false);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersDto);
        }

        [HttpGet("{login}")]
        public IActionResult Get(string login)
        {
            var user = _repository.GetByUserName(login, trackChanges: false);

            if (user == null)
            {
                return NotFound($"User with login '{login}' doesn't exist in datebase");
            }
            else
            {
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
        }
    }
}
