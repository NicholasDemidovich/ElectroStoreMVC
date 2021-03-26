using System;
using Microsoft.EntityFrameworkCore;


namespace ElectroStoreMVC.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.IsDeleted).HasDefaultValue(0);
        }

    }
}
