using HotelSearch.Application.Contracts;

namespace HotelSearch.Application.Payloads.Requests
{
    public class PaginateRequest : IPaginated
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
