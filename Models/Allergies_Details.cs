using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Test.Models
{
    public class Allergies_Details : BaseEntity
    {        
        public Patient Patient { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public Allergies Allergies { get; set; }
        [ForeignKey("AllergiesId")]
        public int AllergiesId { get; set; }

        public Allergies_Details()
        {
            //Allergies = new Allergies();
            //Patient = new Patient();
        }
    }
}
