using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    internal class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"deleating Restaurant with id = {request.Id} ");
            var restaurant = await restaurantsRepository.GetRestaurantByIDAsync(request.Id);
            if (restaurant is null)
            {
                return false;
            }

            await restaurantsRepository.DeleteRestaurant(restaurant);
            return true;
        }


    }
}
