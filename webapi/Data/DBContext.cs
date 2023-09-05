using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options): base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}