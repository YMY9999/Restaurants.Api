using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Dishes.Queries.GetAllDishesForRestaurant
{
    public class GetAllDishesForRestaurantQueryHandler(
            IRestaurantsRepository restaurantsRepository,
            IMapper mapper) : IRequestHandler<GetAllDishesForRestaurantQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetAllDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetRestaurantByIDAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException($"restaurant with id :{request.RestaurantId} doesn't exist");

            var result = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
            return result;
        }
    }
}
