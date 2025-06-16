using AutoMapper;
using FluentValidation;
using HotelSearch.Application.Contracts;
using HotelSearch.Application.Payloads.Responses;
using HotelSearch.Infrastructure;
using HotelSearch.Model;
using HotelSearch.Service.Payloads.Requests;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace HotelSearch.Application.Services
{
    public class HotelService : IBaseService<AddUpdateHotelRequest, GetHotelResponse>
    {
        private readonly HotelSearchDbContext _context;
        private readonly IMapper _mapper;
        private const int WGS84Srid = 4326;
        // Create a static GeometryFactory to be efficient.
        private static readonly GeometryFactory _geometryFactory = new GeometryFactory(new PrecisionModel(), WGS84Srid);
        //private readonly IValidator<AddUpdateHotelRequest> _addUpdateValidator;

        //, IValidator<AddUpdateHotelRequest> addUpdateValidator
        public HotelService(HotelSearchDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            //_addUpdateValidator = addUpdateValidator;
        }

        public async Task<Guid> AddAsync(AddUpdateHotelRequest data)
        {
            try
            {
                //await _addUpdateValidator.ValidateAndThrowAsync(data);

                var entity = _mapper.Map<Hotel>(data);

                _context.Hotel.Add(entity);

                await _context.SaveChangesAsync();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GetHotelResponse> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Hotel
                    .AsNoTracking()
                    .Where(x => !x.IsDeleted && x.Id == id)
                    .FirstOrDefaultAsync();

                if (result == null)
                {
                    throw new KeyNotFoundException();
                }

                return _mapper.Map<GetHotelResponse>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            try
            {
                var result = await _context.Hotel
                    .Where(x => !x.IsDeleted && x.Id == id)
                    .FirstOrDefaultAsync();

                if (result == null)
                {
                    throw new KeyNotFoundException();
                }

                result.IsDeleted = true;
                result.DeletedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Guid id, AddUpdateHotelRequest data)
        {
            try
            {
                var result = await _context.Hotel
                    .Where(x => !x.IsDeleted && x.Id == id)
                    .FirstOrDefaultAsync();

                if (result == null)
                {
                    throw new KeyNotFoundException();
                }

                result.Location = CreatePointFromLatLon(Convert.ToDouble(data.Latitude), Convert.ToDouble(data.Longitude));

                result.Price = data.Price;
                result.Name = data.Name;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static Point CreatePointFromLatLon(double latitude, double longitude)
        {
            // IMPORTANT: The order is Longitude, then Latitude!
            return _geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
        }
    }
}
