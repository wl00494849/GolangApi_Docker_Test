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
        public HomeController(ISqlClient sqlClient,WorkToolEntity workToolEntity,IUntityFunction untity)
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
            return View();
        }
        public void CreateWork(Work work)
        {
            if(ModelState.IsValid)
            {
                work.WorkID = string.IsNullOrWhiteSpace(work.WorkID) ? _untity.AutoProduceID("W",_db.Works) : work.WorkID;
                _db.Add(work); 
                _db.SaveChanges();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
