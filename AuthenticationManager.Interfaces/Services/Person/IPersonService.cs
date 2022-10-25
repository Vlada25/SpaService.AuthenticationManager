using AuthenticationManager.DTO.User;

namespace AuthenticationManager.Interfaces.Services.Person
{
    public interface IPersonService
    {
        Task CreateClient(RegisterUser registerUser, Guid userId);
        Task CreateClient(RegisterClientUser registerUser, Guid userId);
        Task CreateMaster(RegisterMasterUser registerUser, Guid userId);
        Task DeleteClient(Guid userId);
        Task DeleteMaster(Guid userId);
    }
}
