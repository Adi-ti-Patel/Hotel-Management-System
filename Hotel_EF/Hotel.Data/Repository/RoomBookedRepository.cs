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
    public class RoomBookedRepository : IRoomBookedRepository
    {
        private readonly HotelDbContext dbContext;
        public RoomBookedRepository(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateItem(RoomBooked item)
        {
            this.dbContext.RoomBooked.Add(item);
            this.dbContext.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var obj = this.dbContext.RoomBooked.FirstOrDefault(item => item.Id == id);
            if (obj != null)
            {
                this.dbContext.Remove(obj);
                this.dbContext.SaveChanges();
            }
            return obj != null;
        }

        public List<RoomBooked> GetAllItems()
        {
            return this.dbContext.RoomBooked.ToList();
        }

        public RoomBooked GetItemById(int id)
        {
            return this.dbContext.RoomBooked.FirstOrDefault(item => item.Id == id);
        }

        public RoomBooked UpdateItem(RoomBooked item)
        {
            var exists = this.dbContext.RoomBooked.Any(p => p.Id == item.Id);
            if (exists == true)
            {
                this.dbContext.RoomBooked.Update(item);
                this.dbContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}
