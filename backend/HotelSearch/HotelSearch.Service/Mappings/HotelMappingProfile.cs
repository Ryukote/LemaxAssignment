using AutoMapper;
using HotelSearch.Application.Payloads.Responses;
using HotelSearch.Model;
using HotelSearch.Service.Payloads.Requests;
using HotelSearch.Utility;
using NetTopologySuite.Geometries;

namespace HotelSearch.Application.Mappings
{
    public class HotelMappingProfile : Profile
    {
        // SRID 4326 is the standard for GPS coordinates (WGS 84).
        // It's crucial for accurate distance calculations.
        private const int WGS84Srid = 4326;

        // Create a static GeometryFactory to be efficient.
        private static readonly GeometryFactory _geometryFactory = new GeometryFactory(new PrecisionModel(), WGS84Srid);

        public HotelMappingProfile() 
        {
            CreateMap<Hotel, GetHotelResponse>()
                .ForMember(
                    dest => dest.Latitude,
                    opt => opt.MapFrom(src => src.Location.Y)
                )
                .ForMember(
                    dest => dest.Longitude,
                    opt => opt.MapFrom(src => src.Location.X)
                );

            CreateMap<AddUpdateHotelRequest, Hotel>()
                .ForMember(
                    dest => dest.Location,
                    opt => opt.MapFrom(src => PostGISUtility.CreatePointFromLatLon(Convert.ToDouble(src.Latitude), Convert.ToDouble(src.Longitude)))
                );
        }
    }
}
