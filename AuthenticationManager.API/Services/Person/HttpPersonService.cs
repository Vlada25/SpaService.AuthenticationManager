﻿using AuthenticationManager.Domain.Models.Person;
using AuthenticationManager.DTO.User;
using AuthenticationManager.Interfaces.Services.Person;

namespace AuthenticationManager.API.Services.Person
{
    public class HttpPersonService : IHttpPersonService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string _clientsHost = "https://localhost:7051/api/Clients/";
        private readonly string _mastersHost = "https://localhost:7051/api/Masters/";

        public void CreateClient(RegisterUser registerUser, Guid userId)
        {
            PersonForCreation person = new PersonForCreation
            {
                Name = registerUser.Name,
                Surname = registerUser.Surname,
                MiddleName = registerUser.MiddleName,
                PhoneNumber = "",
                UserId = userId
            };

            _httpClient.PostAsJsonAsync(_clientsHost + "Create", person);
        }

        public void CreateMaster(RegisterUser registerUser, Guid userId)
        {
            PersonForCreation person = new PersonForCreation
            {
                Name = registerUser.Name,
                Surname = registerUser.Surname,
                MiddleName = registerUser.MiddleName,
                PhoneNumber = "",
                UserId = userId
            };

            _httpClient.PostAsJsonAsync(_mastersHost + "Create", person);
        }

        public void DeleteClient(Guid userId)
        {
            _httpClient.DeleteAsync(_clientsHost + $"DeleteByUserId/{userId}");
        }

        public void DeleteMaster(Guid userId)
        {
            _httpClient.DeleteAsync(_mastersHost + $"DeleteByUserId/{userId}");
        }
    }
}
