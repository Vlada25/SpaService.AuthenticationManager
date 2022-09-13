using AuthenticationManager.Domain.Configuration;
using AuthenticationManager.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationManager.Database
{
    public class AuthManagerDbContext : IdentityDbContext<User>
    {
        public AuthManagerDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfig());
        }
    }
}
