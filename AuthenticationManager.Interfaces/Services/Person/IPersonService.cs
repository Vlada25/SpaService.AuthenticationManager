using AuthenticationManager.DTO.User;

namespace AuthenticationManager.Interfaces.Services.Person
{
    public interface IPersonService
    {
        Task CreateClient(RegisterUser registerUser, Guid userId);
        Task CreateMaster(RegisterUser registerUser, Guid userId);
        Task DeleteClient(Guid userId);
        Task DeleteMaster(Guid userId);
    }
}
