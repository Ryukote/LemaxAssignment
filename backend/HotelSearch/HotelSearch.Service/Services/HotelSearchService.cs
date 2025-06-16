using AutoMapper;
using HotelSearch.Application.Contracts;
using HotelSearch.Application.Payloads.Requests;
using HotelSearch.Application.Payloads.Responses;
using HotelSearch.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace HotelSearch.Application.Services
{
    public class HotelSearchService : IHotelSearchService<GetHotelDistanceResponse, PaginateHotelRequest>
    {
        private readonly HotelSearchDbContext _context;
        private readonly IMapper _mapper;
        
        public HotelSearchService(HotelSearchDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetPaginatedResponse<GetHotelDistanceResponse>> GetSortedHotelsServerSideAsync(PaginateHotelRequest request)
        {
            try
            {
                var userLocation = new Point(request.UserLongitude, request.UserLatitude) { SRID = 4326 };

                // 1. Let the DATABASE do the work.
                var sortedHotels = await _context.Hotel
                    .OrderBy(hotel => hotel.Location.Distance(userLocation))
                    .ThenBy(hotel => hotel.Price)
                    .Select(hotel => new GetHotelDistanceResponse
                    {
                        Id = hotel.Id,
                        Name = hotel.Name,
                        Price = hotel.Price,
                        DistanceInKm = hotel.Location.Distance(userLocation) / 1000
                    })
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                return new GetPaginatedResponse<GetHotelDistanceResponse>()
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    Result = sortedHotels
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
