using DotNetApi.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Model.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                    .HasMany(e => e.Product)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.CategoryId);


            modelBuilder.Entity<Order>()
                 .HasMany(e => e.OrderDetails)
                 .WithOne(e => e.Order)
                 .HasForeignKey(e => e.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId);
        }


    }
}
