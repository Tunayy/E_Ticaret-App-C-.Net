using Microsoft.EntityFrameworkCore;
using E_Commerce.Entities;


namespace E_Commerce.DataAccess.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Images> Images { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasQueryFilter(p => p.Status);  // Sadece aktif ürünler getirilecek
            modelBuilder.Entity<Products>().HasQueryFilter(p => p.Status);
            modelBuilder.Entity<Images>().HasQueryFilter(p => p.Status);
        }
    }
}
