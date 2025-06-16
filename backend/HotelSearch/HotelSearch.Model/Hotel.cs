namespace HotelSearch.Model
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required decimal Longitude { get; set; }
        public required decimal Latitude { get; set; }

        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
