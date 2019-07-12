using Microsoft.AspNetCore.Mvc;
using Wolftech_CC.Src;

namespace Wolftech_CC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        // GET api/json
        [HttpGet]
        public ActionResult<string> Get()
        {
            Main fr = new Main();
            return fr.GetJson();
        }       
    }
}
