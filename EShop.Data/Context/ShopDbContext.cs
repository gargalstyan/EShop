using EShop.Data.Entitiy;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data.Context
{
    public class ShopDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-V2GBCBV\\SQLEXPRESS;" +
                "Initial Catalog=ShopDB; Integrated Security=true;" +
                "TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.ShopId).IsRequired(false);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }


    }
}