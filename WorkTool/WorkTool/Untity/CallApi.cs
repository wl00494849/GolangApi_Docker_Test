using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WorkTool.Untity
{
    public class CallApi
    {
        public string CallGolangApi(Uri uri,string json)
        {
            var jsonStr = "";
            using (var client = new HttpClient())
            {
                var content = new StringContent(json);
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
    }
}
