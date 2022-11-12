using Hwork.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sql = "DELETE FROM Users WHERE Id=@Id";

            var dbHelper = new SqlDbHelper("default");

            try
            {
                var parameters = new SqlParameterBuilder()
                         .AddNInt("Id", 3)
                         .Build();

                dbHelper.ExecuteNonQuery(sql, parameters);

                Console.WriteLine("紀錄已刪除");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"操作失敗,原因:{ex.Message}");
            }
        }
    }
}
