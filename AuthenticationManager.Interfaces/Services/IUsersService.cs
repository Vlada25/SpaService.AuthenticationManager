using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Interfaces.Services
{
    public interface IUsersService
    {
        IEnumerable<UserDto> GetAll();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> GetByLoginAsync(string login);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllMastersAsync();

    }
}
