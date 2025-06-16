using FluentValidation;
using HotelSearch.Application.Payloads.Requests;

namespace HotelSearch.Application.Validations
{
    public class PaginateHotelRequestValidator : AbstractValidator<PaginateHotelRequest>
    {
        public PaginateHotelRequestValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("Page number must be at least 1.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100).WithMessage("Page size must be between 1 and 100.");

            RuleFor(x => x.UserLatitude)
                .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

            RuleFor(x => x.UserLongitude)
                .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");
        }
    }
}
