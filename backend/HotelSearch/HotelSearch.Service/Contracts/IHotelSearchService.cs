using HotelSearch.Service.Contracts;

namespace HotelSearch.Application.Contracts
{
    public interface IHotelSearchService<TResponse, TPaginate>
        where TResponse : IResponse
        where TPaginate : IPaginateHotelSearch
    {
        Task<List<TResponse>> GetSortedHotelsServerSideAsync(TPaginate request);
    }
}
