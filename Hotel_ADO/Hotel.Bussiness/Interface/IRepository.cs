using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Bussiness.Interface
{
    public interface IRepository<T>
    {
        List<T> GetAllItems();

        T GetItemById(int id);

        bool CreateItem(T item);

        T UpdateItem(T item);

        bool DeleteItem(int id);
    }
}
