using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hwork.Utility
{
    public class SqlDbHelper
    {
        private string connstring;
        public SqlDbHelper(string keyOfconnString)
        {
            connstring = System.Configuration.ConfigurationManager
                                    .ConnectionStrings[keyOfconnString]
                                    .ConnectionString;
        }

        public void ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(connstring))
            {

                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();


                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();

            }
        }
        public DataTable Select(string sql, SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(connstring))
            {
                var command = new SqlCommand(sql, conn);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "blue");

                return dataset.Tables["blue"];
            }


        }
    }
}
