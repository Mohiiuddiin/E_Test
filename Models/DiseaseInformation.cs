using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace E_Test.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class DiseaseInformation : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
    }
}
