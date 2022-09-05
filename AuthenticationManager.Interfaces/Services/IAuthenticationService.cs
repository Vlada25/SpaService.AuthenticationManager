using AuthenticationManager.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(LoginUser loginUser);
        Task<string> CreateToken();
    }
}
