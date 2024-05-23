using E_Test.Models;
using E_Test.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Test.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private IBaseRepository<DiseaseInformation> _diseaseInformation;
        public DiseaseController(IBaseRepository<DiseaseInformation> diseaseInformation)
        {
            _diseaseInformation = diseaseInformation;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _diseaseInformation.GetAllAsync();
            return Ok(data.ToList());
        }
    }
}
