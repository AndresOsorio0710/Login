using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}