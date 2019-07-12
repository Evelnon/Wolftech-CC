﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace Wolftech_CC.Src.Sources
{

    public interface IReader
    {
        string[] ReadFile();

        StringBuilder FormatFile();

        List<News> MapToObject();
    }

}
