using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wolftech_CC.Src.Counting;

namespace Wolftech_CC.Src.Grouping
{
    public class Group : IElementGrouping
    {
        List<News> _news;
        ICounting countingDecorator;

        public Group(List<News> news, ICounting count)
        {
            _news = news;
            countingDecorator = count;
        }

        public List<News> DeleteNonValidElements()
        {
            _news.RemoveAll(x => x.DepartmentParent_OID > 0 && x.Departments.Count == 0);
            return _news;
        }

        public List<News> GroupByDepartment()
        {
            foreach (News item in _news)
            {
                item.Departments.AddRange(_news.FindAll(x => item.Oid == x.DepartmentParent_OID));
                item.NumDecendants = countingDecorator.GetNumberOfDescendants(item);
            }
            return _news;
        }

        public string GetGroupedJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(_news);
        }
    }
}
