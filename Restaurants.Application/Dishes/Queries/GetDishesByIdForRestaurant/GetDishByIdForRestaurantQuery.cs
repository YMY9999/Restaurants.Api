using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishesByIdForRestaurant
{
    public class GetDishByIdForRestaurantQuery(int restaurantid, int dishid) : IRequest<DishDto>
    {
        public int Restaurantid { get; } = restaurantid;
        public int Dishid { get; } = dishid;
    }
}
