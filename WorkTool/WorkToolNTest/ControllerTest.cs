using NUnit.Framework;
using System;
using NSubstitute;
using WorkTool.Controllers;
using WorkTool.Models.DataModel;
using WorkTool.Services;
using WorkTool.Interface;
using WorkTool.Models;
using WorkToolNTest;

namespace WorkToolNTest
{
    public class Tests
    {
        HomeController home;
        private ISqlClient _sqlClient;
        private IUntityFunction _untity;
        private WorkToolEntity _db;

        [SetUp]
        public void Setup()
        {
            var service = new ServicesBuilder();
            _sqlClient = service.GerService<ISqlClient>();
            _untity = service.GerService<IUntityFunction>();
            _db = service.GerService<WorkToolEntity>();
        }

        [Test]
        public void CreateWorkTest()
        {
            home = new HomeController(_sqlClient, _db, _untity);
            var work = new Work()
            {
                WorkContents = "eqweqwe",
                WorkName = "測試用",
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };

            home.CreateWork(work);

            Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            
            Assert.Pass();
        }
    }
}