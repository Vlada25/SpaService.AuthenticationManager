using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.User;
using AuthenticationManager.Interfaces.Services;
using AuthenticationManager.Interfaces.Services.Person;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationManager.API.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IPersonService _personService;

        public UsersService(UserManager<User> userManager,
            IMapper mapper,
            IPersonService personService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _personService = personService;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return false;
            }

            await _userManager.DeleteAsync(user);

            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles.Contains("Master"))
            {
                await _personService.DeleteMaster(id);
            }
            else
            {
                await _personService.DeleteClient(id);
            }

            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDto;
        }

        public async Task<IEnumerable<UserDto>> GetAllMastersAsync()
        {
            var users = _userManager.Users;
            List<User> masters = new List<User>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Contains("Master"))
                {
                    masters.Add(user);
                }
            }

            return _mapper.Map<IEnumerable<UserDto>>(masters);
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user); ;
        }

        public async Task<UserDto> GetByLoginAsync(string login)
        {
            var user = await _userManager.FindByNameAsync(login);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
