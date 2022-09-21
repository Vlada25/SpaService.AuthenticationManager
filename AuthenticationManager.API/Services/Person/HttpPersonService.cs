using AuthenticationManager.Domain.Models.Person;
using AuthenticationManager.DTO.User;
using AuthenticationManager.Interfaces.Services.Person;

namespace AuthenticationManager.API.Services.Person
{
    public class HttpPersonService : IPersonService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string _clientsHost;
        private readonly string _mastersHost;

        public HttpPersonService(string host)
        {
            _clientsHost = host + "/Clients/";
            _mastersHost = host + "/Masters/";
        }

        public async Task CreateClient(RegisterUser registerUser, Guid userId)
        {
            PersonForCreation person = new PersonForCreation
            {
                Name = registerUser.Name,
                Surname = registerUser.Surname,
                MiddleName = registerUser.MiddleName,
                PhoneNumber = "",
                UserId = userId
            };

            await _httpClient.PostAsJsonAsync(_clientsHost + "Create", person);
        }

        public async Task CreateClient(RegisterClientUser registerUser, Guid userId)
        {
            PersonForCreation person = new PersonForCreation
            {
                Name = registerUser.Name,
                Surname = registerUser.Surname,
                MiddleName = registerUser.MiddleName,
                PhoneNumber = "",
                UserId = userId
            };

            await _httpClient.PostAsJsonAsync(_clientsHost + "Create", person);
        }

        public async Task CreateMaster(RegisterUser registerUser, Guid userId)
        {
            PersonForCreation person = new PersonForCreation
            {
                Name = registerUser.Name,
                Surname = registerUser.Surname,
                MiddleName = registerUser.MiddleName,
                PhoneNumber = "",
                UserId = userId
            };

            await _httpClient.PostAsJsonAsync(_mastersHost + "Create", person);
        }

        public async Task DeleteClient(Guid userId)
        {
            await _httpClient.DeleteAsync(_clientsHost + $"DeleteByUserId/{userId}");
        }

        public async Task DeleteMaster(Guid userId)
        {
            await _httpClient.DeleteAsync(_mastersHost + $"DeleteByUserId/{userId}");
        }
    }
}
