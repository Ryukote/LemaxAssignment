using HotelSearch.Application.Payloads.Requests;
using HotelSearch.Service.Contracts;

namespace HotelSearch.Application.Contracts
{
    public interface IBaseService<TRequest, TResponse, TPaginated>
        where TRequest : IRequest
        where TResponse : IResponse
        where TPaginated : IPaginated
    {
        Task<TResponse> GetByIdAsync(Guid id);
        Task<List<TResponse>> GetPaginatedAsync(PaginateRequest request);
        Task<Guid> AddAsync(TRequest data);
        Task UpdateAsync(Guid id, TRequest data);
        Task SoftDeleteAsync(Guid id);
    }
}
