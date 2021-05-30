using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WorkTool.Models.Interface
{
    public interface ISqlClient
    {
        public SqlConnection Conn();
    }
}
