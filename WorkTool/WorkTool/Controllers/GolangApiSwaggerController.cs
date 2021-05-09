using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorkTool.Controllers
{
    public class GolangApiSwaggerController : Controller
    {
        [HttpPost("CallDockerTestApi")]
        public string CallDockerTestApi()
        {
            var str = "";
            using (var client = new HttpClient())
            {
                var content = new StringContent("");
                var response = client.GetAsync("http://localhost:8787/DockerTest");
                if (response != null)
                {
                    Task task = response.Result.Content.ReadAsStreamAsync().ContinueWith(t =>
                    {
                        var stream = t.Result;
                        using (var reader = new StreamReader(stream))
                        {
                            str = reader.ReadToEnd();
                        }
                    });

                    task.Wait();
                }
            }
            return str;
        }
    }
}