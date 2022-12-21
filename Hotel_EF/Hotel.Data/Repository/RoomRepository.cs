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
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext dbContext;
        public RoomRepository(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateItem(Room item)
        {
            this.dbContext.Room.Add(item);
            this.dbContext.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var obj = this.dbContext.Room.FirstOrDefault(item => item.Id == id);
            if (obj != null)
            {
                this.dbContext.Remove(obj);
                this.dbContext.SaveChanges();
            }
            return obj != null;
        }

        public List<Room> GetAllItems()
        {
            return this.dbContext.Room.ToList();
        }

        public Room GetItemById(int id)
        {
            return this.dbContext.Room.FirstOrDefault(item => item.Id == id);
        }

        public Room UpdateItem(Room item)
        {
            var exists = this.dbContext.Room.Any(p => p.Id == item.Id);
            if (exists == true)
            {
                this.dbContext.Room.Update(item);
                this.dbContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}
