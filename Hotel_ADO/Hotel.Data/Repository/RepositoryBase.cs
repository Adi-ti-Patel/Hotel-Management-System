using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Repository
{
    public class RepositoryBase
    {
        protected readonly IConfiguration configuration;

        public RepositoryBase(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public int ExecuteNonQuery(string query, List<SqlParameter> parameters = null)
        {
            string sqlDataSource = configuration.GetConnectionString("hotel");
            int affectedRow = 0;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, mycon))
                {
                    if(parameters != null && parameters.Count > 0)
                    {
                        myCommand.Parameters.AddRange(parameters.ToArray());
                    }
                    affectedRow = myCommand.ExecuteNonQuery();
                }
                mycon.Close();
            }

            return affectedRow;
        }

        public List<T> GetItems<T>(string query, List<SqlParameter> parameters = null)
        {
            DataTable table = new DataTable();
            string sqlDataSource = configuration.GetConnectionString("hotel");
            using (SqlConnection conn = new SqlConnection(sqlDataSource))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Count > 0)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    SqlDataReader  reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                }
                conn.Close();
            }

            string serObj = JsonConvert.SerializeObject(table);
            return JsonConvert.DeserializeObject<List<T>>(serObj);
        }

        public bool DeleteItem(string query, int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@id", SqlDbType.BigInt)
            {
                Value = id
            };
            parameters.Add(para);
            int affectedRow = this.ExecuteNonQuery(query, parameters);

            return affectedRow != 0;
        }

        public T GetItemById<T>(string query, int id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter para = new SqlParameter("@id", SqlDbType.BigInt)
            {
                Value = id
            };
            parameters.Add(para);
            var data = this.GetItems<T>(query, parameters);

            return (data != null && data.Count > 0) ? data[0] : default(T);
        }
    }
}
