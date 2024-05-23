using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Test.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        public TestController()
        {
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = new List<int>() { 1,2,3,4,5};
            return Ok(obj);
        }
    }
}
