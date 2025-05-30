using AutoMapper;
using Restaurants.Domain.Entitys;

namespace Restaurants.Application.Dishes.Dtos
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DishDto>();

        }
    }
}
