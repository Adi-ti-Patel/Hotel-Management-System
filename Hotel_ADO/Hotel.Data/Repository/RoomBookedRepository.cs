using Hotel.Bussiness.Interface;
using Hotel.Bussiness.Model;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Data.Repository
{
    public class RoomBookedRepository : RepositoryBase, IRoomBookedRepository
    {
        public RoomBookedRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool CreateItem(RoomBooked item)
        {
            string query = @"INSERT INTO dbo.RoomBooked (BookingId, RoomId) VALUES (@BookingId, @RoomId)";
            
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@BookingId", SqlDbType.BigInt);
            para.Value = item.BookingId;
            parameters.Add(para);

            para = new SqlParameter("@RoomId", SqlDbType.SmallInt);
            para.Value = item.RoomId;
            parameters.Add(para);

            int affectedRow = base.ExecuteNonQuery(query, parameters);

            return affectedRow != 0;

        }


        public bool DeleteItem(int id)
        {
            string query = @"DELETE FROM dbo.RoomBooked WHERE id = @id";
            return base.DeleteItem(query, id);
        }

        public List<RoomBooked> GetAllItems()
        {
            string query = @"select * from dbo.RoomBooked";
            return base.GetItems<RoomBooked>(query);
        }

        public RoomBooked GetItemById(int id)
        {
            string query = @"select * from dbo.RoomBooked where id = @id";
            return base.GetItemById<RoomBooked>(query, id);
        }

        public RoomBooked UpdateItem(RoomBooked item)
        {
            string query = @"UPDATE dbo.Booking SET BookingId = @BookingId, RoomId = @RoomId WHERE id = @id";

            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@id", SqlDbType.BigInt);
            para.Value = item.Id;
            parameters.Add(para);

            para = new SqlParameter("@BookingId", SqlDbType.BigInt);
            para.Value = item.BookingId;
            parameters.Add(para);

            para = new SqlParameter("@RoomId", SqlDbType.SmallInt);
            para.Value = item.RoomId;
            parameters.Add(para);

            int affectedRow = base.ExecuteNonQuery(query, parameters);
            return affectedRow != 0 ? item : null;

        }
    }
}

