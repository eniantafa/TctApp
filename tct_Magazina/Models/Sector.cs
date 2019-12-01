using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tct_Magazina.Models
{
    public class Sector
    {

        [Key]
        public int SectorId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public List<Warehouse> Warehouses { get; set; }


        public DateTime DateTimeCreated { get; set; }


        [Display(Name = "Last Modified on:")]
        public DateTime DateTimeModified { get; set; }



        public virtual Manager Manager{ get; set; }
        public  int ManagerId { get; set; }
    }
}
