using Restaurants.Domain.Entitys;

namespace Restaurants.Domain.Repository
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIDAsync(int id);
        Task<int> CreateNewRestaurant(Restaurant restaurant);

    }
}
