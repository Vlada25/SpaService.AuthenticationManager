using AuthenticationManager.DTO.User;

namespace AuthenticationManager.Interfaces.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> GetByLoginAsync(string login);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllMastersAsync();

    }
}
