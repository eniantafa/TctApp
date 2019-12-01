using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Enums;

namespace tct_Magazina.Models
{
    public class Warehouse
    {

        [Key]
        public int WarehouseId { get; set; }
        [Required]
        public string Name { get; set; }

        public int Area { get; set; }

        public WarehouseLocation Location{ get; set; }


        [Display(Name = "Number of Workers")]
        public int NoOfWorkers { get; set; }

        public DateTime DateTimeCreated { get; set; }

        [Display(Name = "Last Modified on:")]
        public DateTime DateTimeModified { get; set; }

        public virtual Sector Sector { get; set; }
        public int SectorId { get; set; }


    }
}
