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

            RuleFor(x => x.Latitude)
                .GreaterThanOrEqualTo(-90)
                .WithErrorCode(ErrorCodes.HotelLatitudeTooLow)
                .WithMessage("Latitude cannot be lower than -90 degrees");

            RuleFor(x => x.Latitude)
                .LessThanOrEqualTo(90)
                .WithErrorCode(ErrorCodes.HotelLatitudeTooHigh)
                .WithMessage("Latitude cannot be higher than 90 degrees");

            RuleFor(x => x.Longitude)
                .GreaterThanOrEqualTo(-90)
                .WithErrorCode(ErrorCodes.HotelLongitudeTooLow)
                .WithMessage("Longitude cannot be lower than -90 degrees");

            RuleFor(x => x.Longitude)
                .LessThanOrEqualTo(-90)
                .WithErrorCode(ErrorCodes.HotelLongitudeTooHigh)
                .WithMessage("Longitude cannot be higher than 90 degrees");
        }
    }
}
