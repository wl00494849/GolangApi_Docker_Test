using NUnit.Framework;
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
        public void Setup(ISqlClient sql, WorkToolEntity work, IUntityFunction untity)
        {
            home = new HomeController(sql, work, untity);
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