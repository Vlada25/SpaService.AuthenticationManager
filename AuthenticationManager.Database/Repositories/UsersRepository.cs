using AuthenticationManager.Domain.Models;
using AuthenticationManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Database.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private AuthManagerDbContext _dbContext;

        public UsersRepository(AuthManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAll(bool trackChanges) =>
            !trackChanges ? _dbContext.Set<User>().AsNoTracking() : _dbContext.Set<User>();

        public User GetById(Guid id, bool trackChanges) =>
            !trackChanges?
                _dbContext.Set<User>().Where(u => u.Id.Equals(id)).AsNoTracking().SingleOrDefault() :
                _dbContext.Set<User>().Where(u => u.Id.Equals(id)).SingleOrDefault();

        public User GetByUserName(string userName, bool trackChanges) =>
            !trackChanges ?
                _dbContext.Set<User>().Where(u => u.UserName.Equals(userName)).AsNoTracking().SingleOrDefault() :
                _dbContext.Set<User>().Where(u => u.UserName.Equals(userName)).SingleOrDefault();
    }
}
