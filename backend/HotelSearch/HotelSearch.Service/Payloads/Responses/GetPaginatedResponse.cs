using HotelSearch.Service.Contracts;

namespace HotelSearch.Application.Payloads.Responses
{
    public class GetPaginatedResponse<TResponse>
        where TResponse : IResponse
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public ICollection<TResponse>? Result { get; set; }
        public int Total { get; set; }
    }
}
