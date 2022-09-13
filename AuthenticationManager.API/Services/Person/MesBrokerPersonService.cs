using AuthenticationManager.DTO.User;
using AuthenticationManager.Interfaces.Services.Person;
using MassTransit;
using SpaService.Domain.Messages.User;

namespace AuthenticationManager.API.Services.Person
{
    public class MesBrokerPersonService : IPersonService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MesBrokerPersonService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task CreateClient(RegisterUser registerUser, Guid userId)
        {
            UserClientCreated user = new UserClientCreated
            {
                Id = userId,
                Surname = registerUser.Surname,
                Name = registerUser.Name,
                MiddleName = registerUser.MiddleName
            };

            await _publishEndpoint.Publish(user);
        }

        public async Task CreateMaster(RegisterUser registerUser, Guid userId)
        {
            UserMasterCreated user = new UserMasterCreated
            {
                Id = userId,
                Surname = registerUser.Surname,
                Name = registerUser.Name,
                MiddleName = registerUser.MiddleName
            };

            await _publishEndpoint.Publish(user);
        }

        public async Task DeleteClient(Guid userId)
        {
            UserClientDeleted user = new UserClientDeleted
            {
                Id = userId
            };

            await _publishEndpoint.Publish(user);
        }

        public async Task DeleteMaster(Guid userId)
        {
            UserMasterDeleted user = new UserMasterDeleted
            {
                Id = userId
            };

            await _publishEndpoint.Publish(user);
        }
    }
}
