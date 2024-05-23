using E_Test.Models;

namespace E_Test.Repository.IRepository
{
    public interface IPatientRepository
    {
        Task<List<Allergies>> GetAllergiesByPatient(int patient_Id);
        Task<List<NCD>> GetNCDsByPatient(int patient_Id);
    }
}
