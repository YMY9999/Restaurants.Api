using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    internal class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"deleating Restaurant with id = {request.Id} ");
            var restaurant = await restaurantsRepository.GetRestaurantByIDAsync(request.Id);
            if (restaurant is null)
            {
                throw new NotFoundException($"Restaurant with {request.Id} doesn't exist");
            }

            await restaurantsRepository.DeleteRestaurant(restaurant);
        }


    }
}
