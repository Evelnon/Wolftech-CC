using System.Diagnostics;
using System.Linq;

namespace Wolftech_CC.Src.Counting
{
    public abstract class EntityCounting : ICounting
    {
        private ICounting counting;

        protected EntityCounting(ICounting counting)
        {
            this.counting = counting;            
        }


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
