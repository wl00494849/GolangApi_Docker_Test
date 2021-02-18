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
        private readonly ISqlClient _sqlClient;
        private readonly IUntityFunction _untity;
        private readonly WorkToolEntity _db;
        public HomeController(ISqlClient sqlClient, WorkToolEntity workToolEntity, IUntityFunction untity)
        {
            _sqlClient = sqlClient;
            _db = workToolEntity;
            _untity = untity;
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
                    work.WorkID = _untity.AutoProduceID("W", _db.Work);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
