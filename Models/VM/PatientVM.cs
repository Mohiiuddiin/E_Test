using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Test.Models.VM
{
    public class PatientVM
    {
        //public virtual Patient Patient { get; set; }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int DiseaseInformation_Id { get; set; }
        [Required]
        public string has_Epilepsy { get; set; }
        public virtual List<Allergies>? Allergies { get; set; }
        public virtual List<NCD>? NCDs { get; set; }

        public PatientVM()
        {
            //Patient = new Patient();
            Allergies = new List<Allergies>();
            NCDs = new List<NCD>();
        }
    }
}
