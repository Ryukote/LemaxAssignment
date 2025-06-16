using HotelSearch.Application.Payloads.Responses;
using HotelSearch.Service.Contracts;

namespace HotelSearch.Application.Contracts
{
    public interface IHotelSearchService<TResponse, TPaginate>
        where TResponse : IResponse
        where TPaginate : IPaginateHotelSearch
    {
        Task<GetPaginatedResponse<TResponse>> GetSortedHotelsServerSideAsync(TPaginate request);
    }
}
