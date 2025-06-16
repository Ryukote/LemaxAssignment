using System.Drawing;
using AutoMapper;
using FluentAssertions;
using HotelSearch.Application.Payloads.Requests;
using HotelSearch.Application.Services;
using HotelSearch.Infrastructure;
using HotelSearch.Model;
using Microsoft.EntityFrameworkCore;
using Moq;
using NetTopologySuite.Geometries;
using Xunit;

namespace HotelSearch.Test
{
    public class HotelServiceTests
    {
        private readonly HotelSearchDbContext _context;
        private readonly HotelService _hotelService;

        // The constructor sets up a fresh in-memory database for each test run.
        public HotelServiceTests()
        {
            var options = new DbContextOptionsBuilder<HotelSearchDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new HotelSearchDbContext(options);
            var mockMapper = new Mock<IMapper>();

            // We don't need a real mapper for this specific test, so we can pass null or a mock.
            _hotelService = new HotelService(_context, mockMapper.Object);
        }

        [Fact]
        public async Task GetSortedHotels_ShouldReturn_ClosestAndCheapestHotelFirst()
        {
            // ARRANGE
            // Seed the in-memory database with test data
            _context.Hotel.AddRange(new List<Hotel>
            {
                new Hotel { Id = Guid.NewGuid(), Name = "Westin", Price = 500, Location = new NetTopologySuite.Geometries.Point(16.0, 45.9) { SRID = 4326 } },
                new Hotel { Id = Guid.NewGuid(), Name = "Sheraton", Price = 100, Location = new NetTopologySuite.Geometries.Point(15.97, 45.81) { SRID = 4326 } },
                new Hotel { Id = Guid.NewGuid(), Name = "Zonar", Price = 300, Location = new NetTopologySuite.Geometries.Point(15.98, 45.82) { SRID = 4326 } }
            });
            await _context.SaveChangesAsync();

            var request = new PaginateRequest
            {
                PageNumber = 1,
                PageSize = 10
            };

            // ACT
            var result = await _hotelService.GetPaginatedAsync(request);

            // ASSERT
            result.Result.Should().NotBeNull();
            result.Result.Should().HaveCount(3);

            // Verify the sorting logic
            result!.Result!.First().Name.Should().Be("Close and Cheap");
            result!.Result!.Last().Name.Should().Be("Far and Expensive");
        }
    }
}
