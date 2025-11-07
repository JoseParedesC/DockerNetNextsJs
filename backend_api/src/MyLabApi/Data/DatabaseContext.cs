using Microsoft.EntityFrameworkCore;
using MyLabApi.Models;

namespace MyLabApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<Products> Products { get; set; }
    }
}
