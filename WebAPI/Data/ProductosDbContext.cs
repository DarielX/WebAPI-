using Microsoft.EntityFrameworkCore;
using WEBAPI.Models;

namespace WEBAPI.Data
{
    public class ProductosDbContext : DbContext
    {
        public ProductosDbContext(DbContextOptions<ProductosDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoD>()
                .Property(p => p.Precio)
                .HasPrecision(18, 2); // Adjust precision and scale as needed
        }
        public DbSet<ProductoD> ProductosD{ get; set; }


    }
}
