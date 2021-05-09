using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkTool.Interface;
using Microsoft.Extensions.Logging;
using WorkTool.Models.DataModel;
using WorkTool.Models;
using Microsoft.AspNetCore.Http;
namespace WorkTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWork _work;
        private readonly ILogger _logger;
        private readonly IUntityFunction _unity;
        public HomeController(IWork work, ILogger<HomeController> logger, IUntityFunction untity)
        {
            _work = work;
            _logger = logger;
            _unity = untity;
        }

        [HttpPost("CreateWork")]
        public IActionResult CreateWork(Work work)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _work.Create(work);
                    return RedirectToAction("Work");
                }
                return View(work);
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return RedirectToAction("Error");
            }
        }
        [HttpPost("DeleteWork")]
        public void DeleteWork(string workID)
        {
            try
            {
                _work.Delete(workID);
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }

        [HttpPost("DetailWork")]
        public Work DetailWork(string workID)
        {
            return _work.Detail(workID);
        }

        [HttpPost("WorkListJson")]
        public JsonResult WorkListJson()
        {
            return Json(_work.GetList());
        }
        [HttpPost("Upload")]
        public void Upload(IFormFile file)
        {
            _unity.Upload(file);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
