using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateNewDish;
using Restaurants.Application.Dishes.Commands.DeleteDishByIdForRestaurant;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetAllDishesForRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishesByIdForRestaurant;

namespace Restaurants.Api.Controllers
{
    [Route("api/restaurant/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateNewDishCommand Command)
        {
            Command.RestaurantId = restaurantId;
            var Dishid = await mediator.Send(Command);
            return CreatedAtAction(nameof(GetDishesById), new { restaurantId, Dishid }, null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllDishesForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetAllDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{Dishid}")]
        public async Task<ActionResult<DishDto>> GetDishesById([FromRoute] int restaurantId, [FromRoute] int Dishid)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, Dishid));
            return Ok(dish);
        }

        [HttpDelete("{Dishid}")]
        public async Task<ActionResult<DishDto>> DeleteDishesById([FromRoute] int restaurantId, [FromRoute] int Dishid)
        {
            await mediator.Send(new DeleteDishByIdForRestaurantCommand(restaurantId, Dishid));
            return NoContent();
        }

    }
}
