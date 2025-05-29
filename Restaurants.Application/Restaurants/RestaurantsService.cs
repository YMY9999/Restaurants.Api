using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entitys;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
        ILogger<RestaurantsService> logger) : IRestaurantsService
    {
        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            logger.LogInformation("Fetching all restaurants from the repository.");
            var Restaurants = await restaurantsRepository.GetAllRestaurantsAsync();
            return Restaurants;
        }

        public async Task<Restaurant> GetRestaurantByID(int id)
        {
            logger.LogInformation("Fetching the restaurant from the repository.");
            var Restaurant = await restaurantsRepository.GetRestaurantByIDAsync(id);
            return Restaurant;
        }
    }
}
