using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.DatabaseContext.DatabaseContext
{
    public class EcommerceDatabaseContext : DbContext
    {
        private IConfiguration _configuration;

        public EcommerceDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PurchesOrder> PurchesOrders { get; set; }
        public DbSet<PurchesOrderItem> PurchesOrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = _configuration.GetConnectionString("AppConnectionString");
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }

        //navigation property
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Shop>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>()
                .HasOne<Shop>(c => c.Shop)
                .WithMany(d => d.Products)
                .HasForeignKey(x => x.ShopId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasQueryFilter(c => c.IsDeleted == false);
        }


    }
}