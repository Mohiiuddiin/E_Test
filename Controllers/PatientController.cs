using E_Test.Models;
using E_Test.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Numerics;
using System.Text;

namespace E_Test.Controllers
{
    public class PatientController : Controller
    {
        HttpClient client = new HttpClient();
        const string base_url = "https://localhost:7159/api/";
        public PatientController()
        {

        }
        public async Task<IActionResult> Index()
        {
            List<Patient>? patients = new List<Patient>();
            HttpResponseMessage allergy_resp = await client.GetAsync(base_url + "PatientApi");
            if (allergy_resp.IsSuccessStatusCode)
            {
                patients = await allergy_resp.Content.ReadFromJsonAsync<List<Patient>>();
            }
            return View(patients);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.allergies = new List<Allergies>();
            ViewBag.ncds = new List<NCD>();
            ViewBag.disease = new List<DiseaseInformation>();

            HttpResponseMessage allergy_resp = await client.GetAsync(base_url + "allergies");
            if (allergy_resp.IsSuccessStatusCode)
            {
                ViewBag.allergies = await allergy_resp.Content.ReadFromJsonAsync<List<Allergies>>();
            }

            HttpResponseMessage ncds_resp = await client.GetAsync(base_url + "ncd");
            if (ncds_resp.IsSuccessStatusCode)
            {
                ViewBag.ncds = await ncds_resp.Content.ReadFromJsonAsync<List<NCD>>();
            }

            HttpResponseMessage disease_resp = await client.GetAsync(base_url + "disease");
            if (disease_resp.IsSuccessStatusCode)
            {
                ViewBag.disease = await disease_resp.Content.ReadFromJsonAsync<List<DiseaseInformation>>();
            }
            PatientVM patientVM = new PatientVM();
            return View(patientVM);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PatientVM patient)
        {
            PatientVM patient1 = new PatientVM();
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Save Failed";
                return View();
            }
            HttpResponseMessage response = await client.PostAsJsonAsync(
                base_url + "PatientApi", patient);
            response.EnsureSuccessStatusCode();

            //using (var httpClient = new HttpClient())
            //{
            //    StringContent content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");

            //    using (var response = await httpClient.PostAsync(base_url + "PatientApi", content))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        patient1 = JsonConvert.DeserializeObject<PatientVM>(apiResponse);
            //    }
            //}

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.allergies = new List<Allergies>();
            ViewBag.ncds = new List<NCD>();
            ViewBag.disease = new List<DiseaseInformation>();

            HttpResponseMessage allergy_resp = await client.GetAsync(base_url + "allergies");
            ViewBag.allergies = allergy_resp.IsSuccessStatusCode ? await allergy_resp.Content.ReadFromJsonAsync<List<Allergies>>() : null;

            HttpResponseMessage ncds_resp = await client.GetAsync(base_url + "ncd");
            ViewBag.ncds = ncds_resp.IsSuccessStatusCode ? await ncds_resp.Content.ReadFromJsonAsync<List<NCD>>() : null;

            HttpResponseMessage disease_resp = await client.GetAsync(base_url + "disease");
            ViewBag.disease = disease_resp.IsSuccessStatusCode ? await disease_resp.Content.ReadFromJsonAsync<List<DiseaseInformation>>() : null;

            Patient? patient = new Patient();
            HttpResponseMessage patient_resp = await client.GetAsync(base_url + "PatientApi/" + id);
            patient = disease_resp.IsSuccessStatusCode ? await patient_resp.Content.ReadFromJsonAsync<Patient>() : null;

            PatientVM patientVM = new PatientVM();
            if (patient != null)
            {
                patientVM.Id = patient.Id;
                patientVM.Name = patient.Name;
                patientVM.DiseaseInformation_Id = patient.DiseaseInformationId;
                patientVM.has_Epilepsy = patient.has_Epilepsy;

                HttpResponseMessage allergyDet_resp = await client.GetAsync(base_url + "PatientApi/GetAllergiesByPatientId?patient_id=" + patient.Id);
                patientVM.Allergies = allergyDet_resp.IsSuccessStatusCode ? await allergyDet_resp.Content.ReadFromJsonAsync<List<Allergies>>() : null;

                HttpResponseMessage ncdDet_resp = await client.GetAsync(base_url + "PatientApi/GetNCDsByPatientId?patient_id=" + patient.Id);
                patientVM.NCDs = ncdDet_resp.IsSuccessStatusCode ? await ncdDet_resp.Content.ReadFromJsonAsync<List<NCD>>() : null;
            }

            return View(patientVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatientVM patient)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Save Failed";
                return View();
            }
            HttpResponseMessage response = await client.PutAsJsonAsync(
                base_url + "PatientApi", patient);
            //HttpResponseMessage response = await client.PutAsJsonAsync(
            //    $"PatientApi/products/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
    }
}
