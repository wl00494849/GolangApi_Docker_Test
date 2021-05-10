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
using System;

namespace WorkTool.Controllers
{
    public class GolangApiLeetCodeController : Controller
    {
        [HttpPost("TwoSum")]
        public object TwoSum(LeetCode.TwoSumModel twoSum,string url)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success
            };

            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().GolangTwoSum : url);
            var jsonStr = new CallApi().CallGolangApi(uri,twoSum);

            result.body = JsonConvert.DeserializeObject<LeetCode.TwoSumResult>(jsonStr);

            return result;
        }
    }
}