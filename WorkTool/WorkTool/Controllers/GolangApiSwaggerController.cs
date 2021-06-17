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

namespace WorkTool
{
    public class GolangApiSwaggerController : Controller
    {
        [HttpPost("CallDockerTestApi")]
        public object CallDockerTestApi(string url)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success,
                
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
        [HttpPost("CallDeleteUser")]
        public object CallDeleteUser(string url,int UserID)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success
            };
            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().DeleteUser : url);
            var str = new CallApi().CallGolangApi(uri,UserID);

            result.body = str;

            return result;
        }
        [HttpPost("CallChannlTest")]
        public object CallChannlTest(string url,GolangTest.ChannlTestModel model)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success
            };
            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().GolangChannlTest : url);
            var str = new CallApi().CallGolangApi(uri,model);

            result.body = str;

            return result;
        }
    }
}