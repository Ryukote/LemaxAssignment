namespace HotelSearch.Application.Contracts
{
    public interface IPaginateHotelSearch
    {
        public double UserLatitude { get; set; }
        public double UserLongitude { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
