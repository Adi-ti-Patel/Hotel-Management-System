using Hotel.Bussiness.Interface;
using Hotel.Bussiness.Model;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Data.Repository
{
    public class RoomRepository : RepositoryBase, IRoomRepository
    {
        public RoomRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool CreateItem(Room item)
        {
            string query = @"INSERT INTO dbo.Room (RoomNo, RoomType, RoomSize) VALUES (@RoomNo, @RoomType, @RoomSize)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@RoomNo", SqlDbType.Int);
            para.Value = item.RoomNo;
            parameters.Add(para);

            para = new SqlParameter("@RoomType", SqlDbType.VarChar, 50);
            para.Value = item.RoomType;
            parameters.Add(para);

            para = new SqlParameter("@RoomSize", SqlDbType.Int);
            para.Value = item.RoomSize;
            parameters.Add(para);

            int affectedRow = base.ExecuteNonQuery(query, parameters);

            return affectedRow != 0;
        }

        public bool DeleteItem(int id)
        {
            string query = @"DELETE FROM dbo.Room WHERE id = @id";
            return base.DeleteItem(query, id);
        }

        public List<Room> GetAllItems()
        {
            string query = @"select * from dbo.Room";
            return base.GetItems<Room>(query);
        }

        public Room GetItemById(int id)
        {
            string query = @"select * from dbo.Room where id = @id";
            return base.GetItemById<Room>(query, id);
        }

        public Room UpdateItem(Room item)
        {
            string query = @"UPDATE dbo.Room SET RoomNo = @RoomNo, RoomType = @RoomType, RoomSize = @RoomSize WHERE id = @id";

            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@id", SqlDbType.SmallInt);
            para.Value = item.Id;
            parameters.Add(para);

            para = new SqlParameter("@RoomNo", SqlDbType.Int);
            para.Value = item.RoomNo;
            parameters.Add(para);

            para = new SqlParameter("@RoomType", SqlDbType.VarChar, 50);
            para.Value = item.RoomType;
            parameters.Add(para);

            para = new SqlParameter("@RoomSize", SqlDbType.Int);
            para.Value = item.RoomSize;
            parameters.Add(para);

            int affectedRow = base.ExecuteNonQuery(query, parameters);
            return affectedRow != 0 ? item : null;

        }
    }
}

