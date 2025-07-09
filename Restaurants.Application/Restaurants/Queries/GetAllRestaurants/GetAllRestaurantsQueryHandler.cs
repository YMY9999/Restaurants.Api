using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    internal class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
       IMapper mapper,
       IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Fetching all restaurants from the repository.");
            var Restaurants = await restaurantsRepository.GetAllRestaurantsAsync();
            var RestaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(Restaurants);
            return RestaurantsDtos;
        }
    }
}
