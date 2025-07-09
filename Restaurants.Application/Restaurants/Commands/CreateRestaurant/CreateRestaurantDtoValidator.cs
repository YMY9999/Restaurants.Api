using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        private readonly List<string> isvalid = ["indian", "mexican"];
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name)
                .Length(1, 100);


            RuleFor(dto => dto.Category)
                .Must(isvalid.Contains)
                .WithMessage("choose from the valid categories");

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress().WithMessage("Not a valid Email");

            RuleFor(dto => dto.ZipCode)
                .Matches(@"^\d{2}-\d{3}$")
                .WithMessage("enter a valid zip code (XX-XXX)");
        }
    }
}
