using Microsoft.EntityFrameworkCore;
using E_Commerce.Entities;


namespace E_Commerce.DataAccess.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<ProductsProperties> ProductsProperties { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<MainCategories> MainCategories { get; set; }
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasQueryFilter(p => p.Status);  // Sadece aktif ürünler getirilecek
            modelBuilder.Entity<Products>().HasQueryFilter(p => p.Status);
            modelBuilder.Entity<Images>().HasQueryFilter(p => p.Status);
            modelBuilder.Entity<Properties>().HasQueryFilter(p => p.Status);
            modelBuilder.Entity<Users>().HasQueryFilter(p => p.Status);

            modelBuilder.Entity<ProductsProperties>()
           .HasKey(pp => new { pp.ProductId, pp.PropertyId });

            modelBuilder.Entity<ProductsProperties>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.Properties)
                .HasForeignKey(pp => pp.ProductId);

            modelBuilder.Entity<ProductsProperties>()
                .HasOne(pp => pp.Property)
                .WithMany(p => p.Products)
                .HasForeignKey(pp => pp.PropertyId);
        }
    }
}
