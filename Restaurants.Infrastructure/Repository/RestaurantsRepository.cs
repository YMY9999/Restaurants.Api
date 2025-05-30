using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entitys;
using Restaurants.Domain.Repository;
using Restaurants.Infrastructure.DbContext;

namespace Restaurants.Infrastructure.Repository
{
    internal class RestaurantsRepository(RestaurantsDbContext _Db) : IRestaurantsRepository
    {

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
