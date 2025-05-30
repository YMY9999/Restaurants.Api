using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Extention
{
    public static class ServiseCollectionExtention
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantsService, RestaurantsService>();
            services.AddAutoMapper(
               typeof(RestaurantsProfile).Assembly,
               typeof(DishesProfile).Assembly
               );
        }
    }
}
