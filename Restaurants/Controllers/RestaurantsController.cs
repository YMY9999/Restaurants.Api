using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantsService _restaurantsService;
        public RestaurantsController(IRestaurantsService restaurantsDbContext)
        {
            _restaurantsService = restaurantsDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var Restaurants = await _restaurantsService.GetAllRestaurants();
            return Ok(Restaurants);

        }

        [HttpGet("GetRestaurantByID")]
        public async Task<IActionResult> GetRestaurantByID(int id)
        {
            var Restaurant = await _restaurantsService.GetRestaurantByID(id);
            if (Restaurant == null)
            {
                return NotFound($"Restaurant with ID {id} not found.");
            }
            return Ok(Restaurant);

        }

    }
}
