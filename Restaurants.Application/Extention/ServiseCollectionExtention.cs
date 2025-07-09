using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Dtos;


namespace Restaurants.Application.Extention
{
    public static class ServiseCollectionExtention
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //automapper
            services.AddAutoMapper(
               typeof(RestaurantsProfile).Assembly,
               typeof(DishesProfile).Assembly
               );
            //fluent validation
            services.AddValidatorsFromAssembly(typeof(CreateRestaurantCommand).Assembly)
                .AddFluentValidationAutoValidation();
            //mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServiseCollectionExtention).Assembly));

        }
    }
}
