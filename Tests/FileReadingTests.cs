using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Text;
using Wolftech_CC.Src;
using Wolftech_CC.Src.ErrorHandling;
using Wolftech_CC.Src.Sources;

namespace Tests
{
    [TestClass()]
   public class FileReadingTests
    {

        private Mock<IReader> files = new Mock<IReader>();
               
       
        [TestMethod]
        public void FormatFile_MissingData_Error()
        {            
            string[] wordList = { "test,test1,test2" };
            IReader reader = new FileReader(wordList);
            Assert.ThrowsException<MissingHeaderOrDataException>(() => reader.FormatFile());            
        }

        [TestMethod]
        public void FormatFile_DataError_Error()
        {
            string[] wordList = { "test,,test1,test2", "0,0,0" };
            IReader reader = new FileReader(wordList);
            Assert.ThrowsException<ErrorParsingFileException>(() => reader.FormatFile());
        }

        [TestMethod]
        public void FormatFile_Success()
        {
            IReader reader = GetStringBuildOutput();
            Assert.IsTrue(reader.FormatFile().Length > 0);
        }

        [TestMethod]
        public void MapToObject_Success()
        {
            IReader reader = GetStringBuildOutput();
            
            List<News> newsList = reader.MapToObject();
            Assert.IsTrue(newsList.Count > 0);
        }

        private IReader GetStringBuildOutput()
        {
            string[] wordList = { "test,test1,test2", "0,0,0" };
            var reader = new FileReader(new StringBuilder(), wordList);
            reader.FormatFile();
            return reader;
        }

    }
}
