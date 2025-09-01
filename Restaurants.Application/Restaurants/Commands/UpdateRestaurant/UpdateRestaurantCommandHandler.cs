using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating Resuaraunt");
            var restaurant = await restaurantsRepository.GetRestaurantByIDAsync(request.Id);
            if (restaurant is null)
                throw new NotFoundException($"Restaurant with {request.Id} doesn't exist");


            mapper.Map(request, restaurant);
            await restaurantsRepository.SaveChanges();


        }
    }
}
