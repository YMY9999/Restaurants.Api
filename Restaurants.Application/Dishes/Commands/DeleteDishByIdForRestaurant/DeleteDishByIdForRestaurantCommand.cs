using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDishByIdForRestaurant
{
    public class DeleteDishByIdForRestaurantCommand(int restaurantid, int dishid) : IRequest
    {
        public int Restaurantid { get; } = restaurantid;
        public int Dishid { get; } = dishid;
    }
}
