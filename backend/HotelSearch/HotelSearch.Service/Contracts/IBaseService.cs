using HotelSearch.Application.Payloads.Requests;
using HotelSearch.Application.Payloads.Responses;
using HotelSearch.Service.Contracts;

namespace HotelSearch.Application.Contracts
{
    public interface IBaseService<TRequest, TResponse, TPaginated>
        where TRequest : IRequest
        where TResponse : IResponse
        where TPaginated : IPaginated
    {
        Task<TResponse> GetByIdAsync(Guid id);
        Task<GetPaginatedResponse<TResponse>> GetPaginatedAsync(PaginateRequest request);
        Task<Guid> AddAsync(TRequest data);
        Task UpdateAsync(Guid id, TRequest data);
        Task SoftDeleteAsync(Guid id);
    }
}
