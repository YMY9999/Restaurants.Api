using Restaurants.Domain.Entitys;

namespace Restaurants.Domain.Repository
{
    public interface IDishesRepository
    {
        Task<int> CreateNewDish(Dish dish);
        Task DeleteDish(Dish dish);
    }
}
