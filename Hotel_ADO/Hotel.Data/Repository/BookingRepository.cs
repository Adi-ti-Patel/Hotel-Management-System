using Hotel.Bussiness.Interface;
using Hotel.Bussiness.Model;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Data.Repository
{
    public class BookingRepository : RepositoryBase, IBookingRepository
    {
        public BookingRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool CreateItem(Booking item)
        {
            string query = @"INSERT INTO dbo.Booking (CustomerName, PhoneNo, Address, CityId, BookingDate, CheckIn, CheckOut) VALUES (@CustomerName, @PhoneNo, @Address, @CityId, @BookingDate, @CheckIn, @CheckOut)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@CustomerName", SqlDbType.VarChar, 50);
            para.Value = item.CustomerName;
            parameters.Add(para);

            para = new SqlParameter("@PhoneNo", SqlDbType.VarChar, 50);
            para.Value = item.PhoneNo;
            parameters.Add(para);

            para = new SqlParameter("@Address", SqlDbType.VarChar, 200);
            para.Value = item.Address;
            parameters.Add(para);

            para = new SqlParameter("@CityId", SqlDbType.SmallInt);
            para.Value = item.CityId;
            parameters.Add(para);

            para = new SqlParameter("@BookingDate", SqlDbType.DateTimeOffset);
            para.Value = item.BookingDate;
            parameters.Add(para);

            para = new SqlParameter("@CheckIn", SqlDbType.DateTimeOffset);
            para.Value = item.CheckIn;
            parameters.Add(para);

            para = new SqlParameter("@CheckOut", SqlDbType.DateTimeOffset);
            para.Value = item.CheckOut;
            parameters.Add(para);

            int affectedRow = base.ExecuteNonQuery(query, parameters);

            return affectedRow != 0;
        }

        public bool DeleteItem(int id)
        {
            string query = @"DELETE FROM dbo.Booking WHERE id = @id";
            return base.DeleteItem(query, id);
        }


        public List<Booking> GetAllItems()
        {
            string query = @"SELECT * FROM dbo.Booking";
            return base.GetItems<Booking>(query);
        }

        public Booking GetItemById(int id)
        {
            string query = @"SELECT * FROM dbo.Booking WHERE id = @id";
            return base.GetItemById<Booking>(query, id);
        }

        public Booking UpdateItem(Booking item)
        {
            string query = @"UPDATE dbo.Booking SET CustomerName = @CustomerName, PhoneNo = @PhoneNo, Address = @Address, CityId = @CityId, BookingDate = @BookingDate, CheckIn=@CheckIn, CheckOut=@CheckOut WHERE id = @id";

            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@id", SqlDbType.BigInt);
            para.Value = item.Id;
            parameters.Add(para);

            para = new SqlParameter("@CustomerName", SqlDbType.VarChar, 50);
            para.Value = item.CustomerName;
            parameters.Add(para);

            para = new SqlParameter("@PhoneNo", SqlDbType.VarChar, 50);
            para.Value = item.PhoneNo;
            parameters.Add(para);

            para = new SqlParameter("@Address", SqlDbType.VarChar, 200);
            para.Value = item.Address;
            parameters.Add(para);

            para = new SqlParameter("@CityId", SqlDbType.SmallInt);
            para.Value = item.CityId;
            parameters.Add(para);

            para = new SqlParameter("@BookingDate", SqlDbType.DateTimeOffset);
            para.Value = item.BookingDate;
            parameters.Add(para);

            para = new SqlParameter("@CheckIn", SqlDbType.DateTimeOffset);
            para.Value = item.CheckIn;
            parameters.Add(para);

            para = new SqlParameter("@CheckOut", SqlDbType.DateTimeOffset);
            para.Value = item.CheckOut;

            parameters.Add(para);
            int affectedRow = base.ExecuteNonQuery(query, parameters);
            return affectedRow != 0 ? item : null;
        }
    }
}
