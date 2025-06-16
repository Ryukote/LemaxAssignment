using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using HotelSearch.API;
using HotelSearch.Application.Payloads.Requests;
using HotelSearch.Application.Payloads.Responses;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HotelSearch.Test
{
    public class HotelsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public HotelsControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task POST_Hotels_WithValidBody_ReturnsOkAndPaginatedResult()
        {
            // ARRANGE
            var requestUrl = "/api/Hotels";

            var requestBody = new PaginateHotelRequest
            {
                UserLatitude = 45.815,
                UserLongitude = 15.981,
                PageNumber = 1,
                PageSize = 5
            };

            // ACT
            var response = await _client.PostAsJsonAsync(requestUrl, requestBody);

            // ASSERT
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var pagedResult = await response.Content.ReadFromJsonAsync<GetPaginatedResponse<GetHotelDistanceResponse>>();

            pagedResult.Should().NotBeNull();
            pagedResult.PageNumber.Should().Be(1);
            pagedResult.PageSize.Should().Be(5);
            pagedResult.Result.Should().NotBeNull();
        }
    }
}
