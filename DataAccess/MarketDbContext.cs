using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess
{
    public class MarketDbContext : DbContext
    {
         public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
