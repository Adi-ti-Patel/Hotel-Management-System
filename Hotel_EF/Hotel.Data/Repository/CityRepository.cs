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
    public class CityRepository : ICityRepository
    {
        private readonly HotelDbContext dbContext;
        public CityRepository(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateItem(City item)
        {
            this.dbContext.City.Add(item);
            this.dbContext.SaveChanges();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var obj = this.dbContext.City.FirstOrDefault(item => item.Id == id);
            if (obj != null)
            {
                this.dbContext.Remove(obj);
                this.dbContext.SaveChanges();
            }
            return obj != null;
        }

        public List<City> GetAllItems()
        {
            return this.dbContext.City.ToList();
        }

        public City GetItemById(int id)
        {
            return this.dbContext.City.FirstOrDefault(item => item.Id == id);
        }

        public City UpdateItem(City item)
        {
            var exists = this.dbContext.City.Any(p => p.Id == item.Id);
            if (exists == true)
            {
                this.dbContext.City.Update(item);
                this.dbContext.SaveChanges();
                return item;
            }
            return null;
        }
    }
}
