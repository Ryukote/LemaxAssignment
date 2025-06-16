namespace HotelSearch.Application.Contracts
{
    public interface IPaginated
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
