using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hwork.Utility
{
    public class SqlParameterBuilder
    {
        private List<SqlParameter> parameters = new List<SqlParameter>();
        public SqlParameterBuilder AddNVarchar(string name,int lenght,string value)
        {
            var param = new SqlParameter(name, SqlDbType.NVarChar,lenght){ Value = value };
            parameters.Add(param);
            return this;
        }
        public SqlParameterBuilder AddNInt(string name, int value)
        {
            var param = new SqlParameter(name, SqlDbType.Int){ Value = value };
            parameters.Add(param);
            return this;
        }
        public SqlParameterBuilder AddDateTime(string name, DateTime value)
        {
            var param = new SqlParameter(name,SqlDbType.DateTime){ Value = value };   
            parameters.Add(param);
            return this;
        }

        public SqlParameter[] Build()
        {
            return parameters.ToArray();
        }
    }
}
