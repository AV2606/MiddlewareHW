using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MiddlewareHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        [HttpGet("students/{classnum}/{studentId}")]
        public string handle(string classnum, string studentId)
        {
            // return Ok("{" +
            //   "\"classnum\": \""+classnum+"\",\n"+
            // "\"studentId\": \""+studentId+"\"" +
            //"}");
            var r= "{" + "\n" +
                $"\"classnum\" : \"{classnum}\",\n" +
                $"\"studentid\" : \"{studentId}\"\n"
                + "}";
            return r;
        }

    }
}
