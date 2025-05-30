using AutoMapper;
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
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));

        }
    }

}
