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

namespace WorkTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWork _work;
        private readonly ILogger _logger;
        public HomeController(IWork work,ILogger<HomeController> logger)
        {
            _work = work;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Work()
        {
            try
            {
                return View(_work.GetList());
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return RedirectToAction("Error");
            }
        }
        [HttpGet]
        public IActionResult CreateWork()
        {
            return View();
        }
        [HttpPost]
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
        public IActionResult DeleteWork(string workID)
        {
            try
            {
                _work.Delete(workID);
                return RedirectToAction("Work");
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return RedirectToAction("Error");
            }
        }
        public IActionResult DetailWork(string workID)
        {
            try
            {
                return View(_work.Detail(workID));
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return RedirectToAction("Error");
            }
        }

        public JsonResult WorkListJson()
        {
            return Json(_work.GetList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
