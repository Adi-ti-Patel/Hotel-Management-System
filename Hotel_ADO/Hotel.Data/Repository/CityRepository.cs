using Hotel.Bussiness.Interface;
using Hotel.Bussiness.Model;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Data.Repository
{
    public class CityRepository : RepositoryBase, ICityRepository
    {
        public CityRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public bool CreateItem(City item)
        {
            string query = @"INSERT INTO dbo.City (CityName) VALUES (@CityName)";

            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@CityName", SqlDbType.VarChar, 50);
            para.Value = item.CityName;
            parameters.Add(para);

            int affectedRow = base.ExecuteNonQuery(query, parameters);

            return affectedRow != 0;
        }

        public bool DeleteItem(int id)
        {
            string query = @"DELETE FROM dbo.City WHERE id = @id";
            return base.DeleteItem(query, id);
        }

        public List<City> GetAllItems()
        {
            string query = @"select * from dbo.City";
            return base.GetItems<City>(query);
        }

        public City GetItemById(int id)
        {
            string query = @"select * from dbo.City where id = @id";
            return base.GetItemById<City>(query, id);
        }

        public City UpdateItem(City item)
        {
            string query = @"UPDATE dbo.City SET CityName = @CityName WHERE id = @id";

            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@id", SqlDbType.SmallInt);
            para.Value = item.Id;
            parameters.Add(para);

            para = new SqlParameter("@CityName", SqlDbType.VarChar, 50);
            para.Value = item.CityName;
            parameters.Add(para);

            int affectedRow = base.ExecuteNonQuery(query, parameters);
            return affectedRow != 0 ? item : null;

        }
    }
}
