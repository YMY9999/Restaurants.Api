using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(IMapper mapper,
        ILogger<GetRestaurantByIdQueryHandler> logger,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"getting restaurant");
            var Restaurant = await restaurantsRepository.GetRestaurantByIDAsync(request.Id);
            var RestaurantDtos = mapper.Map<RestaurantDto>(Restaurant);
            return RestaurantDtos;
        }
    }
}
