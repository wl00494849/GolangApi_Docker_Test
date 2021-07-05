using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WorkTool.Models;
using WorkTool.Models.Enum;
using WorkTool.Untity;
using WorkTool.Models.DataModel;

namespace WorkTool.Controllers
{
    public class GolangApiLeetCodeController : Controller
    {
        [HttpPost("TwoSum")]
        public object TwoSum(LeetCode.TwoSumModel twoSum, string url)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success,                
            };

            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().GolangTwoSum : url);
            var jsonStr = new CallApi().CallGolangApi(uri, twoSum);

            result.body = JsonConvert.DeserializeObject<LeetCode.TwoSumResult>(jsonStr);

            return result;
        }
        [HttpPost("Palindrome")]
        public object Palindrome(int num, string url)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success
            };

            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().GolangPalindrome : url);
            var jsonStr = new CallApi().CallGolangApi(uri, num);

            result.body = jsonStr;

            return result;
        }
    }
}