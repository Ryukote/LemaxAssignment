using FluentValidation.TestHelper;
using HotelSearch.Application.Payloads.Requests;
using HotelSearch.Application.Validations;

namespace HotelSearch.Test.Validators
{
    public class PaginateHotelRequestValidatorTests
    {
        private readonly PaginateHotelSearchRequestValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_PageNumber_Is_Less_Than_1()
        {
            var model = new PaginateHotelRequest
            {
                PageNumber = 0,
                PageSize = 10,
                UserLatitude = 45,
                UserLongitude = 15
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PageNumber);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(101)]
        public void Should_Have_Error_When_PageSize_Is_Out_Of_Range(int pageSize)
        {
            var model = new PaginateHotelRequest
            {
                PageNumber = 1,
                PageSize = pageSize,
                UserLatitude = 45,
                UserLongitude = 15
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PageSize);
        }

        [Theory]
        [InlineData(-91)]
        [InlineData(91)]
        public void Should_Have_Error_When_Latitude_Is_Invalid(double latitude)
        {
            var model = new PaginateHotelRequest
            {
                PageNumber = 1,
                PageSize = 10,
                UserLatitude = latitude,
                UserLongitude = 15
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.UserLatitude);
        }

        [Theory]
        [InlineData(-181)]
        [InlineData(181)]
        public void Should_Have_Error_When_Longitude_Is_Invalid(double longitude)
        {
            var model = new PaginateHotelRequest
            {
                PageNumber = 1,
                PageSize = 10,
                UserLatitude = 45,
                UserLongitude = longitude
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.UserLongitude);
        }

        [Fact]
        public void Should_Not_Have_Any_Errors_When_Request_Is_Valid()
        {
            var model = new PaginateHotelRequest
            {
                PageNumber = 2,
                PageSize = 20,
                UserLatitude = 44.9d,
                UserLongitude = 13.2d
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
