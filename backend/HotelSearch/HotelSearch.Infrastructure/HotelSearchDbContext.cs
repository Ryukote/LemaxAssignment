using HotelSearch.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelSearch.Infrastructure
{
    public class HotelSearchDbContext : DbContext
    {
        public HotelSearchDbContext()
        {
        }

        public HotelSearchDbContext(DbContextOptions<HotelSearchDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hotel> Hotel { get; set; }
    }
}
