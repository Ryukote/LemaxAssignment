using FluentValidation;
using HotelSearch.Service.Payloads.Requests;

namespace HotelSearch.Application.Validations
{
    public class AddUpdateHotelRequestValidator : AbstractValidator<AddUpdateHotelRequest>
    {
        public AddUpdateHotelRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must have at least 1 character");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be at least 0. Hotels will not pay you to stay at their place, but it can give you the room for free.");

            RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");
        }
    }
}
