using AuthenticationManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll(bool trackChanges);
        User GetById(Guid id, bool trackChanges);
        User GetByUserName(string userName, bool trackChanges);
    }
}
