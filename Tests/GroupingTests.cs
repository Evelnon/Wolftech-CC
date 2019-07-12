using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Wolftech_CC_Logic.Src;
using Wolftech_CC_Logic.Src.Counting;
using Wolftech_CC_Logic.Src.Grouping;
using Wolftech_CC_Logic.Src.Sources;

namespace Tests
{
    [TestClass()]
    public class GroupingTests
    {
        Group group;
        List<News> newsList;
        IReader iReader;

        [TestInitialize]
        public void TestInit()
        {
            newsList = new List<News>();
            newsList.Add(new News(1, "title1", "#111", 0));
            newsList.Add(new News(2, "title1", "#111", 1));
            newsList.Add(new News(3, "title1", "#111", 2));
            Mock<ICounting> countingMock = new Mock<ICounting>();
            group = new Group(newsList, countingMock.Object);
        }


        [TestMethod]
        public void GroupByDepartment_Group_Success()
        {
            List<News> outcome = group.GroupByDepartment();
            Assert.AreEqual(outcome[0].Departments.Count, 1);
            Assert.AreEqual(outcome[1].Departments.Count, 1);
            Assert.AreEqual(outcome[2].Departments.Count, 0);
        }

        [TestMethod]
        public void DeleteNonValidElements_DeleteItems_Success()
        {
            List<News> outcome = group.DeleteNonValidElements();
            Assert.IsTrue(outcome.Count == 1);
            Assert.AreEqual(outcome[0].Departments.Count, 0);
        }

        [TestMethod]
        public void GetGroupedJson_ReturnsString_Success()
        {

            string jsonString = group.GetGroupedJson();  
            Assert.IsTrue(jsonString != string.Empty);
            List<News> outcomeList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<News>>(jsonString);
            Assert.AreEqual(outcomeList[0].Oid, newsList[0].Oid);



        }

    }
}
