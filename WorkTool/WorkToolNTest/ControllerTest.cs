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
        private ISqlClient _sqlClient;
        private IUntityFunction _untity;
        private WorkToolEntity _db;
        private HomeController home;

        [SetUp]
        public void Setup()
        {
            var service = new ServicesBuilder();
            _sqlClient = service.GerService<ISqlClient>();
            _untity = service.GerService<IUntityFunction>();
            _db = service.GerService<WorkToolEntity>();
            home = new HomeController(_sqlClient, _db, _untity);
        }

        [Test]
        public void CreateWorkTest()
        {
            var work = new Work()
            {
                WorkContents = "測試內容",
                WorkName = "測試用",
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };

            home.CreateWork(work);

            Assert.Pass();
        }
        [Test]
        public void WorkTest()
        {
            home.Work();
            Assert.Pass();
        }
        [Test]
        public void Test()
        {
            
        }
    }
}