using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WorkTool.Interface
{
    public interface ISqlClient
    {
        public SqlConnection Conn();
    }
}
