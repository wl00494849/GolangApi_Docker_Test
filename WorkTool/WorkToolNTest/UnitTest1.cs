using NUnit.Framework;
using NSubstitute;
using WorkTool.Controllers;
using WorkTool.Models.DataModel;
using WorkTool.Services;
using WorkTool.Interface;
using WorkTool.Models;

namespace WorkToolNTest
{
    public class Tests
    {
        HomeController home;
        private ISqlClient _sqlClient;
        private IUntityFunction _untity;
        private WorkToolEntity _db;

        public object Substitute { get; private set; }

        [SetUp]
        public void Setup()
        {
            _sqlClient = Substitute.For<ISqlClient, SqlClient>();
            _untity = Substitute.For<IUntityFunction, UntityFunction>();
            _db = Substitute.For<WorkToolEntity>();
            home = new HomeController(_sqlClient,_db,_untity);
        }

        [Test]
        public void CreateWorkTest()
        {
            home.CreateWork(new Work()
            {
                WorkID = "12345678910",
                WorkContents = "eqweqwe",
            });

            Assert.Pass();
        }
    }
}