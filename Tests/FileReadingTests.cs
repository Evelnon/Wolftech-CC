using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Text;
using Wolftech_CC_Logic.Src;
using Wolftech_CC_Logic.Src.ErrorHandling;
using Wolftech_CC_Logic.Src.Sources;

namespace Tests
{
    [TestClass()]
   public class FileReadingTests
    {

        private Mock<IReader> files = new Mock<IReader>();
        IReader reader;
       
        [TestMethod]
        public void FormatFile_MissingData_Error()
        {            
            string[] wordList = { "test,test1,test2" };
            reader = new FileReader(wordList, new PlainTextFileReader());
            Assert.ThrowsException<MissingHeaderOrDataException>(() => reader.FormatFile());            
        }

        [TestMethod]
        public void FormatFile_DataError_Error()
        {
            string[] wordList = { "test,,test1,test2", "0,0,0" };
            reader = new FileReader(wordList, new PlainTextFileReader());
            Assert.ThrowsException<ErrorParsingFileException>(() => reader.FormatFile());
        }

        [TestMethod]
        public void FormatFile_Success()
        {
            reader = GetStringBuildOutput();
            Assert.IsTrue(reader.FormatFile().Length > 0);
        }

        [TestMethod]
        public void MapToObject_Success()
        {
            reader = GetStringBuildOutput();            
            List<News> newsList = reader.MapToObject();
            Assert.IsTrue(newsList.Count > 0);
        }

        private IReader GetStringBuildOutput()
        {
            string[] wordList = { "test,test1,test2", "0,0,0" };
            reader = new FileReader(new StringBuilder(), wordList, new PlainTextFileReader());
            reader.FormatFile();
            return reader;
        }

    }
}
