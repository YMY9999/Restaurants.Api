using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entitys;
using Restaurants.Domain.Repository;
using Restaurants.Infrastructure.DbContext;

namespace Restaurants.Infrastructure.Repository
{
    internal class RestaurantsRepository(RestaurantsDbContext _Db) : IRestaurantsRepository
    {
        public async Task<int> CreateNewRestaurant(Restaurant restaurant)
        {
            _Db.Restaurants.Add(restaurant);
            await _Db.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            _Db.Restaurants.Remove(restaurant);
            await _Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            var Restaurants = await _Db.Restaurants.ToListAsync();
            return Restaurants;
        }

        public async Task<Restaurant> GetRestaurantByIDAsync(int id)
        {
            var Restaurant = await _Db.Restaurants
                           .Include(d => d.Dishes)
                           .FirstOrDefaultAsync(r => r.Id == id);

            return Restaurant;
        }

    }
}
