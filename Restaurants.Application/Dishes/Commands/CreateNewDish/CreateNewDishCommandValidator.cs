using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateNewDish
{
    public class CreateNewDishCommandValidator : AbstractValidator<CreateNewDishCommand>
    {
        public CreateNewDishCommandValidator()
        {
            RuleFor(dto => dto.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Enter a valid Price");

            RuleFor(dto => dto.KiloCalories)
                     .GreaterThanOrEqualTo(0)
                .WithMessage("KiloCalories must be a positive number");
        }

    }
}
