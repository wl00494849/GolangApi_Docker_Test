using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WorkTool.Interface;

namespace WorkTool.Services
{
    public class SqlClient : ISqlClient
    {
        private string _ConnectionString { get; set; }
        public SqlClient(string SqlConnectionStr)
        {
            _ConnectionString = SqlConnectionStr;
        }
        public SqlConnection Conn()
        {
            return new SqlConnection(_ConnectionString);
        }
    }
}
