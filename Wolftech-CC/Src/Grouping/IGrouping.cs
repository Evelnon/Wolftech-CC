using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wolftech_CC.Src.Grouping
{
    interface IElementGrouping
    {

        List<News> GroupByDepartment();

        List<News> DeleteNonValidElements();

        string GetGroupedJson();

    }
}
