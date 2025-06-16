using HotelSearch.Service.Contracts;

namespace HotelSearch.Application.Contracts
{
    public interface IBaseService<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        Task<TResponse> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(TRequest data);
        Task UpdateAsync(Guid id, TRequest data);
        Task SoftDeleteAsync(Guid id);

    }
}
