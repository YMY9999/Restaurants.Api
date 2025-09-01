using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repository;
using Restaurants.Infrastructure.DbContext;
using Restaurants.Infrastructure.Repository;
using Restaurants.Infrastructure.Seed;

namespace Restaurants.Infrastructure.Extention
{
    public static class ServiseCollectionExtention
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RestaurantsDbContext>(options =>
            options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();

        }
    }
}
