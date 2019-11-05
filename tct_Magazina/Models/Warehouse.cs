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

        public string Location{ get; set; }


        [Display(Name = "Number of Workers")]
        public int NoOfWorkers { get; set; }

        public DateTime DateTimeCreated { get; set; }



      

    }
}
