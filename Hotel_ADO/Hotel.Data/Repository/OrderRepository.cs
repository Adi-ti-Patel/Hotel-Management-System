using Hotel.Bussiness.Interface;
using Hotel.Bussiness.Model;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Data.Repository
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool CreateItem(Order item)
        {
            string query = @"INSERT INTO [dbo].[Order] (BookingId, FoodItem, FoodQuantity, OrderAmount, OrderTime) VALUES (@BookingId, @FoodItem, @FoodQuantity, @OrderAmount, @OrderTime)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@BookingId", SqlDbType.BigInt);
            para.Value = item.BookingId;
            parameters.Add(para);

            para = new SqlParameter("@FoodItem", SqlDbType.VarChar, 1000);
            para.Value = item.FoodItem;
            parameters.Add(para);

            para = new SqlParameter("@FoodQuantity", SqlDbType.TinyInt);
            para.Value = item.FoodQuantity;
            parameters.Add(para);

            para = new SqlParameter("@OrderAmount", SqlDbType.Decimal);
            para.Value = item.OrderAmount;
            parameters.Add(para);

            para = new SqlParameter("@OrderTime", SqlDbType.DateTimeOffset);
            para.Value = item.OrderTime;
            parameters.Add(para);

            int affectedRow = base.ExecuteNonQuery(query, parameters);

            return affectedRow != 0;
        }

        public bool DeleteItem(int id)
        {
            string query = @"DELETE FROM [dbo].[Order] WHERE id = @id";
            return base.DeleteItem(query, id);
        }

        public List<Order> GetAllItems()
        {
            string query = @"SELECT * FROM [dbo].[Order]";
            return base.GetItems<Order>(query);
        }

        public Order GetItemById(int id)
        {
            string query = @"SELECT * FROM [dbo].[Order] WHERE id = @id";
            return base.GetItemById<Order>(query, id);
        }
    

        public Order UpdateItem(Order item)
        {
            string query = @"UPDATE [dbo].[Order] SET BookingId = @BookingId, FoodItem = @FoodItem, FoodQuantity = @FoodQuantity, OrderAmount = @OrderAmount, OrderTime = @OrderTime WHERE id = @id";
            
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@id", SqlDbType.BigInt);
            para.Value = item.Id;
            parameters.Add(para);

            para = new SqlParameter("@BookingId", SqlDbType.BigInt);
            para.Value = item.BookingId;
            parameters.Add(para);

            para = new SqlParameter("@FoodItem", SqlDbType.VarChar, 1000);
            para.Value = item.FoodItem;
            parameters.Add(para);

            para = new SqlParameter("@FoodQuantity", SqlDbType.TinyInt);
            para.Value = item.FoodQuantity;
            parameters.Add(para);

            para = new SqlParameter("@OrderAmount", SqlDbType.Decimal);
            para.Value = item.OrderAmount;
            parameters.Add(para);

            para = new SqlParameter("@OrderTime", SqlDbType.DateTimeOffset);
            para.Value = item.OrderTime;
            parameters.Add(para);

            int affectedRow = base.ExecuteNonQuery(query, parameters);
            return affectedRow != 0 ? item : null;
        }
    }
}
