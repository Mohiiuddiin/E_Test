using System.ComponentModel.DataAnnotations.Schema;

namespace E_Test.Models
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; }
        public DiseaseInformation DiseaseInformation { get; set; }
        [ForeignKey("DiseaseInformationId")]
        public int DiseaseInformationId { get; set; }
        public string has_Epilepsy { get; set; }

        public Patient()
        {
            //DiseaseInformation = new DiseaseInformation();
            has_Epilepsy = Epilepsy.No.ToString();
        }
    }
}
