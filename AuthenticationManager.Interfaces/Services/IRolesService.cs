using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Interfaces.Services
{
    public interface IRolesService
    {
        IEnumerable<IdentityRole> GetAll();
        Task<IEnumerable<string>> GetUserRolesAsync(string login);
    }
}
