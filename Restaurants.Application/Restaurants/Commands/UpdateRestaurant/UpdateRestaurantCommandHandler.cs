using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating Resuaraunt");
            var restaurant = await restaurantsRepository.GetRestaurantByIDAsync(request.Id);
            if (restaurant is null)
                return false;

            mapper.Map(request, restaurant);
            await restaurantsRepository.SaveChanges();

            return true;

        }
    }
}
