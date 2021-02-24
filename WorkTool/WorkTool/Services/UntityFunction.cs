using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTool.Models;
using WorkTool.Interface;
using Microsoft.AspNetCore.Hosting;
using System.Data;

namespace WorkTool.Services
{
    public class UntityFunction : IUntityFunction
    {
        public string AutoProduceID<T>(IEnumerable<T> dataTable,string primarykey)
        {
            return GetNewID(GetLastID(dataTable,primarykey));
        }

        private string GetLastID <T>(IEnumerable<T> dataTable,string primarykey)
        {
            //有點慢...不應該用Reflection
            //找時間修正
            return dataTable.LastOrDefault().GetType().GetProperty(primarykey).GetValue(dataTable.LastOrDefault()).ToString();
        }

        private string GetNewID (string id)
        {
            var newID = (Convert.ToInt32(id) + 1).ToString();
            newID = newID.PadLeft(id.Length,'0');
            return newID;
        }

        public void Pipeline()
        {
            foreach(var iten in new List<DataTable>());
        }
    }
}
