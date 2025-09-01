using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entitys;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Dishes.Commands.CreateNewDish
{
    public class CreateNewDishCommandHandler(ILogger<CreateNewDishCommand> logger,
        IRestaurantsRepository restaurantsRepository,
        IDishesRepository dishesRepository,
        IMapper mapper) : IRequestHandler<CreateNewDishCommand, int>
    {
        public async Task<int> Handle(CreateNewDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("creating new dish");

            var restaurant = restaurantsRepository.GetRestaurantByIDAsync(request.RestaurantId);

            if (restaurant is null) throw new NotFoundException($"restaurant with id :{request.RestaurantId} doesn't exist");

            var dish = mapper.Map<Dish>(request);

            return await dishesRepository.CreateNewDish(dish);



        }
    }
}
