using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var Restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(Restaurants);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantByID([FromRoute] int id)
        {
            var Restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));

            if (Restaurant == null)
            {
                return NotFound($"Restaurant with ID {id} not found.");
            }
            return Ok(Restaurant);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            int id = await mediator.Send(createRestaurantCommand);
            return CreatedAtAction(nameof(GetRestaurantByID), new { id }, null);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            var IsDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
            if (IsDeleted)
                return NoContent();

            return NotFound($"Restaurant with ID {id} not found.");
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand Command)
        {
            Command.Id = id;
            var IsUpdated = await mediator.Send(Command);
            if (IsUpdated)
                return NoContent();

            return NotFound($"Restaurant with ID {id} not found.");

        }


    }
}
