using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exec3_MaintainUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            Console.WriteLine(connstring);

            var conn = new SqlConnection(connstring);
            conn.Open();

            Console.WriteLine("connected");
            conn.Close();
        }
    }
}
