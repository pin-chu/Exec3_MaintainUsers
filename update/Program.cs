using Hwork.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace update
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sql = "UPDATE Users SET Name=@Name,Account=@Account,Password=@Password,Height=@Height,DateOfBirthd=@DateOfBirthd WHERE Id=@Id";

            var dbHelper = new SqlDbHelper("default");

            try
            {
                var parameters = new SqlParameterBuilder()
                         .AddNVarchar("Name", 50, "miko")
                         .AddNVarchar("Account", 50, "test4133")
                         .AddNVarchar("Password", 50, "eeeee")
                         .AddNInt("Height", 90)
                         .AddNInt("Id",2)
                         .AddDateTime("DateOfBirthd", Convert.ToDateTime("1997/06/22"))
                         .Build();

                dbHelper.ExecuteNonQuery(sql, parameters);

                Console.WriteLine("紀錄已UPDATE");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"操作失敗,原因:{ex.Message}");
            }
        }
    }
}
