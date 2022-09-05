using AuthenticationManager.Domain.Models;
using AuthenticationManager.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationManager.API.Services
{
    public class RolesService : IRolesService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<IdentityRole> GetAll()
        {
            return _roleManager.Roles;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string login)
        {
            var user = await _userManager.FindByNameAsync(login);

            if (user == null)
            {
                return null;
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            return userRoles;
        }
    }
}
