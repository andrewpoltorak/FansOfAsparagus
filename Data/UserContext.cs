using FansOfAsparagus.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FansOfAsparagus
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): 
            base(options) 
        { 

        }

        public DbSet<User> Users { get; set; }
    }
}
