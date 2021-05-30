using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTool.Models.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WorkTool.Services
{
    public class UntityFunction : IUntityFunction
    {
        public string AutoProduceID<T>(IEnumerable<T> dataTable,string primarykey)
        {
            return GetNewID(GetLastID(dataTable,primarykey));
        }

        public void Upload(IFormFile file)
        {
            //找時間改虛擬路徑
            var path = $"C:\\Users\\wl004\\OneDrive\\桌面\\WorkTool_Core_MVC\\WorkTool\\WorkTool\\UploadFolder\\{file.FileName}";
            using(var stream = new FileStream(path,FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        private string GetLastID <T>(IEnumerable<T> dataTable,string primarykey)
        {
            //有點慢...不應該用Reflection
            //找時間修正
            var data = dataTable.LastOrDefault();
            return data.GetType().GetProperty(primarykey).GetValue(data).ToString();;
        }

        private string GetNewID (string id)
        {
            var newID = (Convert.ToInt32(id) + 1).ToString();
            newID = newID.PadLeft(id.Length,'0');
            return newID;
        }
    }
}
