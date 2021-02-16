using NUnit.Framework;
using NSubstitute;
using WorkTool.Controllers;
using WorkTool.Models.DataModel;
using WorkTool.Interface;
using WorkTool.Models;

namespace WorkToolNTest
{
    public class Tests
    {
        HomeController home;
        
        [SetUp]
        public void Setup()
        {
            var sql = Substitute.For();
            home = new HomeController();
        }

        [Test]
        public void Test1()
        {
            home.CreateWork(new Work()
            {
                
            });
            Assert.Pass();
        }
    }
}