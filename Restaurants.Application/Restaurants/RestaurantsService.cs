using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
        ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Fetching all restaurants from the repository.");
            var Restaurants = await restaurantsRepository.GetAllRestaurantsAsync();

            //var RestaurantDtos = Restaurants.Select(RestaurantDto.FromEntity);  // Use the static method to map the entity to DTO
            var RestaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(Restaurants); // Use AutoMapper to map the entity to DTO
            return RestaurantsDtos;
        }

        public async Task<RestaurantDto> GetRestaurantByID(int id)
        {
            logger.LogInformation("Fetching the restaurant from the repository.");
            var Restaurant = await restaurantsRepository.GetRestaurantByIDAsync(id);

            //var RestaurantDtos = RestaurantDto.FromEntity(Restaurant); // Use the static method to map the entity to DTO
            var RestaurantDtos = mapper.Map<RestaurantDto>(Restaurant); // Use AutoMapper to map the entity to DTO

            return RestaurantDtos;
        }
    }
}
