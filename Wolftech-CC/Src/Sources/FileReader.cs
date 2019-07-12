using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wolftech_CC.Src.ErrorHandling;

namespace Wolftech_CC.Src.Sources
{
    public class FileReader : IReader
    {
        protected string[] words;
        protected StringBuilder sb; 

        public FileReader()
        {
            sb = new StringBuilder();
        }
        public FileReader(StringBuilder sb)
        {
            this.sb = sb;
        }
        public FileReader(string[] words)
        {
            this.words = words;
        }
        public FileReader(StringBuilder sb, string[] words)
        {
            this.words = words;
            this.sb = sb;
        }


        public string[] ReadFile()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"File\File.txt");

            if (File.Exists(path))
            {
                words = File.ReadAllLines(path);
                if (words.Length == 0)
                    throw new FileEmptyException();
            }
            else
                throw new FileNotFoundException();
            return words;
        }
        public StringBuilder FormatFile()
        {
            if (words.Length < 2) throw new MissingHeaderOrDataException();
            try
            {
                string[] header = words[0].Split(',');
                var line = string.Empty;
                for (var x = 1; x < words.Length; x++)
                {
                    line = "{";
                    string[] item = words[x].Split(',');
                    for (var y = 0; y < item.Length; y++)
                    {
                        line += AddBrackets(header[y]) + ":" + AddBrackets(item[y] == string.Empty ? "0" : item[y]) + ",";
                    }
                    sb.Append(line.Remove(line.Length - 1, 1) + "},");
                }
                sb = sb.Remove(sb.Length - 1, 1).Insert(0, "[").Insert(sb.Length, "]");
            }
            catch (Exception)
            {
                throw new ErrorParsingFileException();
            }
            return sb;
        }

        private string AddBrackets(string text)
        {
            return "\"" + text + "\"";
        }

       
        public List<News> MapToObject()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<News>>(sb.ToString());
        }
        
    }
}
