using AuthenticationManager.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Interfaces.Services.Person
{
    public interface IPersonService
    {
        void CreateClient(RegisterUser registerUser, Guid userId);
        void CreateMaster(RegisterUser registerUser, Guid userId);
        void DeleteClient(Guid userId);
        void DeleteMaster(Guid userId);
    }
}
