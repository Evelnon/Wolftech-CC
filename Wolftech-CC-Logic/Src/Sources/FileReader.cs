using System.Collections.Generic;
using System.Text;

namespace Wolftech_CC_Logic.Src.Sources
{
    public class FileReader : PlainTextFileReader
    {
        private IReader reader = null;
        public FileReader(IReader reader) : base()
        {
            this.reader = reader;
        }
        public FileReader(StringBuilder sb, IReader reader) : base(sb)
        {
            this.reader = reader;
        }
        public FileReader(string[] words, IReader reader) : base(words)
        {
            this.reader = reader;
        }
        public FileReader(StringBuilder sb, string[] words, IReader reader) : base(sb, words)
        {
            this.reader = reader;
        }

        public string[] ReadFile()
        {
            return this.reader.ReadFile();
        }
        public StringBuilder FormatFile()
        {
            return this.reader.FormatFile();
        }

        public List<News> MapToObject()
        {
            return this.reader.MapToObject();
        }


    }
}
