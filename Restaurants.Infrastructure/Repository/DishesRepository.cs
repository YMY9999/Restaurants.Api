using Restaurants.Domain.Entitys;
using Restaurants.Domain.Repository;
using Restaurants.Infrastructure.DbContext;

namespace Restaurants.Infrastructure.Repository
{
    public class DishesRepository(RestaurantsDbContext _Db) : IDishesRepository
    {
        public async Task<int> CreateNewDish(Dish dish)
        {
            _Db.Dishes.Add(dish);
            await _Db.SaveChangesAsync();
            return dish.ID;
        }

        public async Task DeleteDish(Dish dish)
        {
            _Db.Dishes.Remove(dish);
            await _Db.SaveChangesAsync();
        }
    }
}
