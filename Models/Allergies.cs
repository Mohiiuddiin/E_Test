using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace E_Test.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Allergies : BaseEntity
    {
        [Required]
        public string Name { get; set; } = "";
    }
}
