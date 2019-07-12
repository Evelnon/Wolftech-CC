using Microsoft.AspNetCore.Mvc;
using Wolftech_CC_Logic.Src.Counting;
using Wolftech_CC_Logic.Src.Grouping;
using Wolftech_CC_Logic.Src.Sources;

namespace Wolftech_CC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        IElementGrouping group;
        IReader reader;       

        // GET api/json
        [HttpGet]
        public ActionResult<string> Get()
        {
            reader = new FileReader(new PlainTextFileReader());
            reader.ReadFile();
            reader.FormatFile();
            group = new Group(reader.MapToObject(), new EntityCounting());
            group.GroupByDepartment();
            group.DeleteNonValidElements();
            return group.GetGroupedJson();
            
        }       
    }
}
