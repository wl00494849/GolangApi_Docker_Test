using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkTool.Interface;
using Microsoft.Extensions.Logging;
using WorkTool.Models;

namespace WorkTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISqlClient _sqlClient;
        private readonly WorkToolEntity _db;
        public HomeController(ISqlClient sqlClient,WorkToolEntity workToolEntity)
        {
            _sqlClient = sqlClient;
            _db = workToolEntity;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
