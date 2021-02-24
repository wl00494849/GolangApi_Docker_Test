using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
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
            _sqlClient = service.GetService<ISqlClient>();
            _untity = service.GetService<IUntityFunction>();
            _db = service.GetService<WorkToolEntity>();
            home = new HomeController(_sqlClient, _db, _untity);
        }

        [Test]
        public void CreateWorkTest()
        {
            var work = new Work()
            {
                WorkContents = "測試內容",
                WorkName = "測試用",
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
        public void AutoProduceIDTest()
        {
            var newID = _untity.AutoProduceID(_db.Work, "WorkID");
            var newIDTest = (Convert.ToInt32(_db.Work.ToList().LastOrDefault().WorkID) + 1).ToString();
            newIDTest = newIDTest.PadLeft(10, '0');

            Assert.AreEqual(newIDTest, newID);
        }
    }
}