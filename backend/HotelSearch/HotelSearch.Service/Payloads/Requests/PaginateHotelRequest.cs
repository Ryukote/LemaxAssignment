using HotelSearch.Application.Contracts;

namespace HotelSearch.Application.Payloads.Requests
{
    public class PaginateHotelRequest : IPaginateHotelSearch
    {
        public double UserLatitude { get; set; }
        public double UserLongitude { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
