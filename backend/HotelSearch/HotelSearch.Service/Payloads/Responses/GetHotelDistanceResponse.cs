using HotelSearch.Service.Contracts;

namespace HotelSearch.Application.Payloads.Responses
{
    public class GetHotelDistanceResponse : IResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required double DistanceInKm { get; set; }
    }
}
