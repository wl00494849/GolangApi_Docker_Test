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
        private readonly IWorkServers _work;
        public HomeController(IWorkServers work)
        {
            _work = work;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Work()
        {
            try
            {
                return View(_work.GetWorkList());
            }
            catch (System.Exception ex)
            {
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
                    _work.CreateWork(work);
                    return RedirectToAction("Work");
                }
                return View(work);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        public IActionResult DeleteWork(string workID)
        {
            try
            {
                _work.DeleteWork(workID);
                return RedirectToAction("Work");
            }
            catch (System.Exception)
            {
                return RedirectToAction("Error");
            }
        }
        public IActionResult DetailWork(string workID)
        {
            try
            {
                return View(_work.DetailWork(workID));
            }
            catch (System.Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public JsonResult WorkListJson()
        {
            return Json(_work.GetWorkList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
