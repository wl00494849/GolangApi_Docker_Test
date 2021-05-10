using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace WorkTool.Untity
{
    public class CallApi
    {
        public string CallGolangApi(Uri uri)
        {
            var jsonStr = "";
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(uri);
                if (response != null)
                {
                    Task task = response.Result.Content.ReadAsStreamAsync().ContinueWith(t =>
                    {
                        var stream = t.Result;
                        using (var reader = new StreamReader(stream))
                        {
                            jsonStr = reader.ReadToEnd();
                        }
                    });

                    task.Wait();
                }
            }

            return jsonStr;
        }
        public string CallGolangApi<T>(Uri uri, T obj)
        {
            var jsonStr = "";
            var json = JsonConvert.SerializeObject(obj);
            
            using (var client = new HttpClient())
            {
                var content = new StringContent(json,Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri,content);
                if (response != null)
                {
                    Task task = response.Result.Content.ReadAsStreamAsync().ContinueWith(t =>
                    {
                        var stream = t.Result;
                        using (var reader = new StreamReader(stream))
                        {
                            jsonStr = reader.ReadToEnd();
                        }
                    });

                    task.Wait();
                }
            }

            return jsonStr;
        }
    }
}
