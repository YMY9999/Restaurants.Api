using MediatR;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Dishes.Commands.DeleteDishByIdForRestaurant
{
    public class DeleteDishByIdForRestaurantCommandHandler(
        IRestaurantsRepository restaurantsRepository,
        IDishesRepository dishesRepository) : IRequestHandler<DeleteDishByIdForRestaurantCommand>
    {
        public async Task Handle(DeleteDishByIdForRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurantByIDAsync(request.Restaurantid);
            if (restaurant == null) throw new NotFoundException($"restaurant with id :{request.Restaurantid} doesn't exist");

            var dish = restaurant.Dishes.FirstOrDefault(d => d.ID == request.Dishid);
            if (dish == null) throw new NotFoundException($"dish with id :{request.Dishid} doesn't exist");

            await dishesRepository.DeleteDish(dish);


        }
    }
}
