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

namespace WorkNTest
{
    public class Tests
    {
        private IUntityFunction _untity;
        private ICRUD<Work> _work;
        private WorkToolEntity _db;

        [SetUp]
        public void Setup()
        {
            var service = new ServicesBuilder();
            _untity = service.GetService<IUntityFunction>();
            _db = service.GetService<WorkToolEntity>();
            _work = service.GetService<ICRUD<Work>>();
        }
        [Test]
        public void CreateWorkTest()
        {
            var work = new Work()
            {
                WorkID = "Test000000",
                WorkContents = "測試內容",
                WorkName = "測試用",
            };

            _work.Create(work);
            _work.Delete("Test000000");
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
        
        [Test]
        public void WorkListJsonTest()
        {
            var workList = _work.GetList();
            Assert.IsNotEmpty(workList);
        }
    }
}