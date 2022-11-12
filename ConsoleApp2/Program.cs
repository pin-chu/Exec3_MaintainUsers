using Hwork.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbHelper =new SqlDbHelper("default");
            string sql = "SELECT Id,Name,Account,Password,Height,DateOfBirthd FROM Users WHERE Id> @Id ORDER BY Id ASC";
                try
                {

                    var parameters = new SqlParameterBuilder().AddNInt("Id", 0).Build();
                    DataTable users = dbHelper.Select(sql, parameters);
                    foreach (DataRow row in users.Rows)
                    {
                        int id = row.Field<int>("id");
                        string name = row.Field<string>("name");
                        string account = row.Field<string>("account");
                        string password = row.Field<string>("password");
                        int height = row.Field<int>("height");
                        string dateOfBirthd = row.Field<DateTime>("dateOfBirthd").ToString();

                        Console.WriteLine($"Id={id},Name={name},Account={account},Password={password},Height={height},DateOfBirthd={dateOfBirthd}");
                       
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"連線失敗,原因:{ex.Message}");
                }
            
        }
    }
}
