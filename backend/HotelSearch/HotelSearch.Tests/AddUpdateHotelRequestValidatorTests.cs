using FluentValidation.TestHelper;
using HotelSearch.Application.Validations;
using HotelSearch.Service.Payloads.Requests;

namespace HotelSearch.Test.Validators
{
    public class AddUpdateHotelRequestValidatorTests
    {
        private readonly AddUpdateHotelRequestValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new AddUpdateHotelRequest
            {
                Name = "",
                Price = 100,
                Latitude = 45,
                Longitude = 15
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Have_Error_When_Price_Is_Negative()
        {
            var model = new AddUpdateHotelRequest
            {
                Name = "Test",
                Price = -10,
                Latitude = 45,
                Longitude = 15
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Theory]
        [InlineData(-91)]
        [InlineData(91)]
        public void Should_Have_Error_When_Latitude_Is_Invalid(decimal latitude)
        {
            var model = new AddUpdateHotelRequest
            {
                Name = "Test",
                Price = 100,
                Latitude = latitude,
                Longitude = 15
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Latitude);
        }

        [Theory]
        [InlineData(-181)]
        [InlineData(181)]
        public void Should_Have_Error_When_Longitude_Is_Invalid(decimal longitude)
        {
            var model = new AddUpdateHotelRequest
            {
                Name = "Test",
                Price = 100,
                Latitude = 45,
                Longitude = longitude
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Longitude);
        }

        [Fact]
        public void Should_Not_Have_Any_Errors_When_Request_Is_Valid()
        {
            var model = new AddUpdateHotelRequest
            {
                Name = "Valid Hotel",
                Price = 150,
                Latitude = 45.5m,
                Longitude = 16.3m
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
