using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkTool.Untity;
using System.Text;
using Newtonsoft.Json;
using WorkTool.Models.DataModel;
using WorkTool.Models;
using WorkTool.Models.Enum;

namespace WorkTool.Controllers
{
    public class GolangApiSwaggerController : Controller
    {
        [HttpPost("CallDockerTestApi")]
        public object CallDockerTestApi(string url)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success
            };
            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().DockerTest : url);
            var str = new CallApi().CallGolangApi(uri);

            result.body = str;

            return result;
        }
        [HttpPost("CallUsersList")]
        public object CallUsersList(string url)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success
            };

            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().UsersList : url);
            var jsonStr = new CallApi().CallGolangApi(uri);

            result.body = JsonConvert.DeserializeObject<List<User>>(jsonStr);

            return result;
        }
    }
}