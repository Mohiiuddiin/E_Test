using E_Test.Models;
using E_Test.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Test.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private IBaseRepository<Allergies> _allergy;
        public AllergiesController(IBaseRepository<Allergies> allergy)
        {
            _allergy = allergy;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _allergy.GetAllAsync();
            return Ok(data.ToList());
        }
    }
}
