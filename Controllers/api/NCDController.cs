using E_Test.Models;
using E_Test.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Test.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDController : ControllerBase
    {
        private IBaseRepository<NCD> _NCD;
        public NCDController(IBaseRepository<NCD> NCD)
        {
            _NCD = NCD;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _NCD.GetAllAsync();
            return Ok(data.ToList());
        }
    }
}
