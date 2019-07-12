using System.Linq;

namespace Wolftech_CC_Logic.Src.Counting
{
    public class EntityCounting : ICounting
    {
        public int GetNumberOfDescendants(News item)
        {           
           return item.Departments.Where<News>(x => x.DepartmentParent_OID == item.Oid || x.Oid == item.Oid)
           .Select(x => x)
           .ToList()
           .Select(x => GetNumberOfDescendants(x))
           .Sum() + item.Departments.Count(x => x.DepartmentParent_OID == item.Oid);
        }
    }
}
