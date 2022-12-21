using Hotel.Bussiness.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data.DBContext
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<RoomBooked> RoomBooked { get; set; }

        public DbSet<Room> Room { get; set; }
    }
}
