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
        private readonly IUntityFunction _untity;
        private readonly IWorkServers _work;
        private readonly WorkToolEntity _db;
        public HomeController(IWorkServers work,WorkToolEntity workToolEntity, IUntityFunction untity)
        {
            _db = workToolEntity;
            _untity = untity;
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
                var list = _db.Work.ToList();
                return View(list);
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
                    work.WorkID = _untity.AutoProduceID(_db.Work, "WorkID");
                    work.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    _db.Add(work);
                    _db.SaveChanges();
                }

                return RedirectToAction("Work");
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
                var target = _db.Work.Where(m => m.WorkID == workID).FirstOrDefault();
                _db.Remove(target);
                _db.SaveChanges();

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
                var data = _db.Work.Where(m => m.WorkID == workID).FirstOrDefault();
                return View(data);
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
