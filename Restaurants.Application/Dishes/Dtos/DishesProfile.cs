using AutoMapper;
using Restaurants.Application.Dishes.Commands.CreateNewDish;
using Restaurants.Domain.Entitys;

namespace Restaurants.Application.Dishes.Dtos
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DishDto>();
            CreateMap<CreateNewDishCommand, Dish>();
        }
    }
}
