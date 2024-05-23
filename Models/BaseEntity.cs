using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace E_Test.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        //public DateTimeOffset CreatedAt { get; set; }
        //public int Status { get; set; }
        //public string CreatedBy { get; set; }




        public BaseEntity()
        {
            //this.CreatedBy = "Mohiuddin";
            //this.CreatedAt = DateTime.Now;
            //this.Status = 1;
        }
    }
}