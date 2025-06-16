using AutoMapper;
using HotelSearch.Application.Payloads.Responses;
using HotelSearch.Model;
using HotelSearch.Service.Payloads.Requests;

namespace HotelSearch.Application.Mappings
{
    public class HotelMappingProfile : Profile
    {
        public HotelMappingProfile() 
        {
            CreateMap<AddUpdateHotelRequest, Hotel>();
            CreateMap<Hotel, GetHotelResponse>();
        }
    }
}
