using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Domain.Entitys;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantsProfile : Profile
    {
        public RestaurantsProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.ZipCode))
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes))
                .ReverseMap();

            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    City = src.City,
                    ZipCode = src.ZipCode
                }));

            CreateMap<UpdateRestaurantCommand, Restaurant>();
        }
    }

}
