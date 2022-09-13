using Microsoft.AspNetCore.Identity;

namespace AuthenticationManager.Interfaces.Services
{
    public interface IRolesService
    {
        IEnumerable<IdentityRole> GetAll();
        Task<IEnumerable<string>> GetUserRolesAsync(string login);
    }
}
