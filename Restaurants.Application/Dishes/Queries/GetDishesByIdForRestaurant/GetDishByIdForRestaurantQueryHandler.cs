using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Dishes.Queries.GetDishesByIdForRestaurant
{
    public class GetDishByIdForRestaurantQueryHandler(
        IRestaurantsRepository restaurantsRepository,
        IMapper mapper) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurantByIDAsync(request.Restaurantid);
            if (restaurant == null) throw new NotFoundException($"restaurant with id :{request.Restaurantid} doesn't exist");


            var dish = restaurant.Dishes.FirstOrDefault(d => d.ID == request.Dishid);
            if (dish == null) throw new NotFoundException($"dish with id :{request.Dishid} doesn't exist");

            var result = mapper.Map<DishDto>(dish);

            return (result);

        }
    }
}
