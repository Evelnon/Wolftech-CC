using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Wolftech_CC_Logic.Src
{
    public class News
    {
        public readonly Int32 Oid;
        public readonly string Title;
        public readonly string Color;
        [JsonIgnore]
        public readonly int DepartmentParent_OID;
        public List<News> Departments = new List<News>();
        public int NumDecendants;


        public News(Int32 Oid, string Title, string Color, Int32 DepartmentParent_OID)
        {
            this.Oid = Oid;
            this.Title = Title;
            this.Color = Color;
            this.DepartmentParent_OID = DepartmentParent_OID;
        }

    }
}
