using NUnit.Framework;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using NSubstitute;
using WorkTool.Models.DataModel;
using WorkTool.Services;
using WorkTool.Interface;
using WorkTool.Models;
using WorkToolNTest;
using Microsoft.AspNetCore.Http;

namespace WorkNTest
{
    public class WorkTest
    {
        private IUntityFunction _untity;
        private IWork _work;
        private WorkToolEntity _db;
        private ISqlClient _sqlClient;

        [SetUp]
        public void Setup()
        {
            var service = new ServicesBuilder();
            _untity = service.GetService<IUntityFunction>();
            _db = service.GetService<WorkToolEntity>();
            _work = service.GetService<IWork>();
            _sqlClient = service.GetService<ISqlClient>();

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
        [Test]
        public void OpenConnectionTest()
        {
            var conn = _sqlClient.Conn();
            Assert.IsNotNull(conn);
        }
        [Test]
        public void UploadTest()
        {
            var path = "C:\\Users\\wl004\\OneDrive\\桌面\\WorkTool_Core_MVC\\WorkTool\\WorkToolNTest\\TestDocument\\Test.txt";
            var file = new FileStream(path,FileMode.Open);
            var ms = new MemoryStream();
            file.CopyTo(ms);

            IFormFile formFile = new FormFile(
                baseStream:ms,
                baseStreamOffset:0,
                length:file.Length,
                name:"data",
                fileName:"Test.txt"
            );

            _untity.Upload(formFile);

            Assert.Pass();
        }
    }
}