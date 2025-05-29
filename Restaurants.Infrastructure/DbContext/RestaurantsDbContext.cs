using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entitys;

namespace Restaurants.Infrastructure.DbContext
{
    internal class RestaurantsDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L5VR3FS;Database=RestaurantsDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);
        }

    }
}
