using NUnit.Framework;
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
                WorkID = "12345678910",
                WorkContents = "eqweqwe",
            };

            home.CreateWork(work);

            Assert.Pass();
        }
    }
}