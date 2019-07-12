using Wolftech_CC.Src.Counting;
using Wolftech_CC.Src.Grouping;
using Wolftech_CC.Src.Sources;

namespace Wolftech_CC.Src
{
    public class Main
    {        
        IElementGrouping group;
        IReader reader;
        readonly ICounting count;
        

        public string GetJson()
        {
            reader = new FileReader();
            reader.ReadFile();
            reader.FormatFile();
            group = new Group(reader.MapToObject(), new Count(count));
            group.GroupByDepartment();
            group.DeleteNonValidElements();
            return group.GetGroupedJson();
        }

    }
}
