using E_Test.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_Test.Models.VM;

namespace E_Test.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<NCD> NCDs { get; set; }
        public DbSet<Allergies_Details> Allergies_Details { get; set; }
        public DbSet<NCD_Details> NCD_Details { get; set; }
    }
}
