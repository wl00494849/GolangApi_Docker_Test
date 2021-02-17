using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTool.Models;
using WorkTool.Interface;
using Microsoft.AspNetCore.Hosting;

namespace WorkTool.Services
{
    public class UntityFunction : IUntityFunction
    {
        public string AutoProduceID<T>(string dataType, IEnumerable<T> dataTable)
        {
            var newID = "";
            var idNum = dataTable.Count().ToString();
            idNum = idNum.PadLeft(10, '0');
            newID = dataType + idNum;

            return newID;
        }
    }
}
