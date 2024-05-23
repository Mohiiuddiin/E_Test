using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Test.Models
{
    public class NCD_Details : BaseEntity
    {
        public Patient Patient { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public NCD NCD { get; set; }
        [ForeignKey("NCDId")]
        public int NCDId { get; set; }

        public NCD_Details()
        {
            //Patient = new Patient();
            //NCD = new NCD();
        }
    }
}
