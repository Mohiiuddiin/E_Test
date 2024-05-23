using E_Test.Models;
using E_Test.Models.VM;
using E_Test.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Test.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientApiController : ControllerBase
    {
        private IBaseRepository<Patient> _patient;
        private IBaseRepository<NCD_Details> _ncd_details;
        private IBaseRepository<Allergies_Details> _allergies_details;
        private IBaseRepository<Allergies> _allergies;
        private IPatientRepository _patientRepository;
        public PatientApiController(IBaseRepository<Patient> patient, IBaseRepository<NCD_Details> ncd_details, IBaseRepository<Allergies_Details> allergies_details, IPatientRepository patientRepository, IBaseRepository<Allergies> allergies)
        {
            _patient = patient;
            _ncd_details = ncd_details;
            _allergies_details = allergies_details;
            _patientRepository = patientRepository;
            _allergies = allergies;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _patient.GetAllIncluding(x=>x.DiseaseInformation);
            return Ok(data.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _patient.GetAsync(id));
        }

        [HttpGet]
        [Route("GetAllergiesByPatientId")]
        public async Task<ActionResult> GetAllergiesByPatientId(int patient_id)
        {            
            return Ok(await _patientRepository.GetAllergiesByPatient(patient_id));
        }
        [HttpGet]
        [Route("GetNCDsByPatientId")]
        public async Task<ActionResult> GetNCDsByPatientId(int patient_id)
        {
            return Ok(await _patientRepository.GetNCDsByPatient(patient_id));
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PatientVM patient)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Ok(new { msg = "Failed" });
                }
                Patient p = new Patient()
                {
                    Name = patient.Name,
                    DiseaseInformationId = patient.DiseaseInformation_Id,
                    has_Epilepsy = patient.has_Epilepsy
                };
                await _patient.AddAsync(p);

                if (p.Id > 0)
                {
                    if (patient.NCDs != null)
                    {
                        foreach (var item in patient.NCDs)
                        {
                            NCD_Details details = new NCD_Details();
                            details.PatientId = p.Id;
                            details.NCDId = item.Id;                            
                            await _ncd_details.AddAsync(details);
                        }
                    }
                    if (patient.Allergies != null)
                    {
                        foreach (var item in patient.Allergies)
                        {
                            Allergies_Details details = new Allergies_Details();
                            details.PatientId = p.Id;
                            details.AllergiesId = item.Id;
                            await _allergies_details.AddAsync(details);
                        }
                    }
                }
                return Ok(new { msg = "Saved" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }       

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] PatientVM patient)
        {
            try
            {
                Patient to_Edit = await _patient.GetAsync(patient.Id);
                if (!ModelState.IsValid)
                {
                    return Ok(new { msg = "Failed" });
                }

                if (to_Edit != null)
                {
                    to_Edit.Name = patient.Name;
                    to_Edit.DiseaseInformationId = patient.DiseaseInformation_Id;
                    to_Edit.has_Epilepsy = patient.has_Epilepsy;                    
                    await _patient.UpdateAsync(to_Edit, patient.Id);

                    var oldList = await _allergies_details.FindByAsync(x => x.PatientId == patient.Id);                    
                    if (patient.Allergies != null)
                    {
                        foreach (var item in patient.Allergies)
                        {
                            var data = oldList.FirstOrDefault(x => x.AllergiesId == item.Id && x.PatientId == patient.Id);
                            if (data==null)
                            {
                                Allergies_Details details = new Allergies_Details();
                                details.PatientId = patient.Id;
                                details.AllergiesId = item.Id;
                                await _allergies_details.AddAsync(details);
                            }
                            else
                            {
                                oldList.Remove(data);
                            }                   
                        }
                    }
                    foreach (var item in oldList)
                    {
                        await _allergies_details.DeleteAsync(item);
                    }

                    var oldList1 = await _ncd_details.FindByAsync(x => x.PatientId == patient.Id);
                    if (patient.NCDs != null)
                    {
                        foreach (var item in patient.NCDs)
                        {
                            var data = oldList1.FirstOrDefault(x => x.NCDId == item.Id && x.PatientId == patient.Id);
                            if (data == null)
                            {
                                NCD_Details details = new NCD_Details();
                                details.PatientId = patient.Id;
                                details.NCDId = item.Id;
                                await _ncd_details.AddAsync(details);
                            }
                            else
                            {
                                oldList1.Remove(data);
                            }
                        }
                    }
                    foreach (var item in oldList1)
                    {
                        await _ncd_details.DeleteAsync(item);
                    }
                }

                return Ok(new { msg = "Updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
