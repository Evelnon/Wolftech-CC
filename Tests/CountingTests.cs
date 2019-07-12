using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Wolftech_CC.Src;
using Wolftech_CC.Src.Counting;

namespace Tests
{
    [TestClass()]
    public class CountingTests
    {

        ICounting counting;
        ICounting count;
        List<News> _news = new List<News>();

        [TestInitialize]
        public void testInit()
        {
            count = new Count(counting);
            _news.Add(new News(1, "test,", "#111", 0));
            _news.ElementAt(0).Departments.Add(new News(2, "test,", "#111", 1));
            _news.ElementAt(0).Departments.Add(new News(3, "test,", "#111", 1));
            _news.ElementAt(0).Departments.ElementAt(1).Departments.Add(new News(4, "test,", "#111", 3));
        }

        

        [TestMethod]
        public void CountDescendantsWithMultipleTiers_Success()
        {            
            Assert.IsTrue(count.GetNumberOfDescendants(_news.ElementAt(0)) == 3);            
        }

        
    }
}
