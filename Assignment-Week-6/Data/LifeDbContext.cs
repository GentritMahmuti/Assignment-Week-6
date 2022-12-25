using Assignment_Week_6.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Week_6.Data
{
    public class LifeDbContext : DbContext
    {
        public LifeDbContext(DbContextOptions<LifeDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
