using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WorkTool.Interface;
using Microsoft.Extensions.Configuration;

namespace WorkTool.Services
{
    public class SqlClient : ISqlClient
    {
        protected string _ConnectionString { get; set; }
        public SqlClient(IConfiguration configuration)
        {
            _ConnectionString = configuration["ConnectionStrings:WorkToolConnectionString"];
        }
        public SqlConnection Conn()
        {
            return new SqlConnection(_ConnectionString);
        }
    }
}
