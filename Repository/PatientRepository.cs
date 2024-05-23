using E_Test.Data;
using E_Test.Models;
using E_Test.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Test.Repository
{
    public class PatientRepository : IPatientRepository
    {
        internal ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Allergies>> GetAllergiesByPatient(int patient_Id)
        {
            var data = from p in _context.Patients
                       join ad in _context.Allergies_Details on p.Id equals ad.PatientId
                       join a in _context.Allergies on ad.AllergiesId equals a.Id
                       where p.Id == patient_Id
                       select a;
            return await data.ToListAsync();
        }

        public async Task<List<NCD>> GetNCDsByPatient(int patient_Id)
        {
            var data = from p in _context.Patients
                       join ad in _context.NCD_Details on p.Id equals ad.PatientId
                       join a in _context.NCDs on ad.NCDId equals a.Id
                       where p.Id == patient_Id
                       select a;
            return await data.ToListAsync();
        }
    }
}
