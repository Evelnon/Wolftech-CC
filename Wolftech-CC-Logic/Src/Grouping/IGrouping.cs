using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wolftech_CC_Logic.Src.Grouping
{
    public interface IElementGrouping
    {

        List<News> GroupByDepartment();

        List<News> DeleteNonValidElements();

        string GetGroupedJson();

    }
}
