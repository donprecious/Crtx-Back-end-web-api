using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrExtApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/test")]

    public class TestController : Controller
    {
        [HttpGet("api/list")]
        public IActionResult GetList()
        {
            List<string> people = new List<string>();
            string[] s = { "Lucky", "James", "Uche" };
            people.AddRange(s);
            return Ok(people);
        }
    }
}