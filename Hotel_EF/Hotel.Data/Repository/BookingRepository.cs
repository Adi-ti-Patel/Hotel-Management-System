using Hotel.Bussiness.Interface;
using Hotel.Bussiness.Model;
using Hotel.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext dbContext;
        public BookingRepository(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateItem(Booking item)
        {
            this.dbContext.Booking.Add(item);
            this.dbContext.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var obj = this.dbContext.Booking.FirstOrDefault(item => item.Id == id);
            if (obj != null)
            {
                this.dbContext.Remove(obj);
                this.dbContext.SaveChanges();
            }
            return obj != null;
        }

        public List<Booking> GetAllItems()
        {
            return this.dbContext.Booking.ToList();
        }

        public Booking GetItemById(int id)
        {
            return this.dbContext.Booking.FirstOrDefault(item => item.Id == id);
        }

        public Booking UpdateItem(Booking item)
        {
            var exists = this.dbContext.Booking.Any(p => p.Id == item.Id);
            if (exists == true)
            {
                this.dbContext.Booking.Update(item);
                this.dbContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}
