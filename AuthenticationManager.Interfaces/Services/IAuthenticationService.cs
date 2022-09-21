using AuthenticationManager.DTO.User;

namespace AuthenticationManager.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(LoginUser loginUser);
        Task<string> CreateToken();
    }
}
