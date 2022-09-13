using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.User;
using AutoMapper;

namespace AuthenticationManager.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<RegisterUser, User>();
        }
    }
}
