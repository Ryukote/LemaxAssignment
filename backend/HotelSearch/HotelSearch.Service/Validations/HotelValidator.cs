using FluentValidation;
using HotelSearch.Model;

namespace HotelSearch.Application.Validations
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(1)
                .WithErrorCode(ErrorCodes.HotelNameLength)
                .WithMessage("Name must have at least 1 character");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode(ErrorCodes.HotelPriceTooLow)
                .WithMessage("Price must be at least 0. Hotels will not pay you to stay at their place, but it can give you the room for free.");
        }
    }
}
