using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entitys;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool HasDelivery { get; set; }

        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }

        public List<DishDto> Dishes { get; set; } = new List<DishDto>();

        public static RestaurantDto FromEntity(Restaurant restaurant)
        {
            return new RestaurantDto
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Category = restaurant.Category,
                HasDelivery = restaurant.HasDelivery,
                Street = restaurant.Address?.Street,
                City = restaurant.Address?.City,
                ZipCode = restaurant.Address?.ZipCode,
                Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList()


            };
        }
    }
}
