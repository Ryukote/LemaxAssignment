using HotelSearch.Service.Contracts;

namespace HotelSearch.Service.Payloads.Requests
{
    public class AddUpdateHotelRequest : IRequest
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required decimal Longitude { get; set; }
        public required decimal Latitude { get; set; }
    }
}
