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
    public class CQRS_GolangTestController : Controller
    {
        [HttpPost("CQRS_UserCreate")]
        public object CQRS_UserCreate(string url, User model)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success,
            };

            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().CQRS_Create : url);
            var jsonStr = new CallApi().CallGolangApi(uri, model);

            result.body = jsonStr;
            return result;
        }
        [HttpPost("CQRS_UserDelete")]
        public object CQRS_UserDelete(string url, int UserID)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success
            };

            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().CQRS_UserDelete : url);
            var jsonStr = new CallApi().CallGolangApi(uri, UserID);

            result.body = jsonStr;

            return result;
        }
        [HttpPost("CQRS_UserList")]
        public object CQRS_UserList(string url)
        {
            BaseResultModel<object> result = new BaseResultModel<object>()
            {
                isSuccess = true,
                response = ResponseCode.ResultCode.Success
            };

            Uri uri = new Uri(string.IsNullOrEmpty(url) ? new DockerUrl().CQRS_UserList : url);
            var jsonStr = new CallApi().CallGolangApi(uri);

            result.body = JsonConvert.DeserializeObject<List<User>>(jsonStr);

            return result;
        }
    }
}