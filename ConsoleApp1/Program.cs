using Hwork.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sql = "INSERT INTO Users(Name,Account,Password,Height,DateOfBirthd)VALUES(@Name,@Account,@Password,@Height,@DateOfBirthd)";

            var dbHelper = new SqlDbHelper("default");
          
                try
                {        
                   var parameters = new SqlParameterBuilder()
                            .AddNVarchar("Name", 50, "jeff")
                            .AddNVarchar("Account", 50, "test852")
                            .AddNVarchar("Password", 50, "idn")
                            .AddNInt("Height", 80)
                            .AddDateTime("DateOfBirthd",Convert.ToDateTime("1995/10/13"))
                            .Build();
    
                    dbHelper.ExecuteNonQuery(sql,parameters);

                    Console.WriteLine("紀錄已新增");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"操作失敗,原因:{ex.Message}");
                }
     
        }
    }
}
