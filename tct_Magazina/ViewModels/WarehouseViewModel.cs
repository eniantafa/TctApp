using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Enums;
using tct_Magazina.Models;

namespace tct_Magazina.ViewModels
{
    public class WarehouseViewModel
    {

       
        [Required]
        public string Name { get; set; }

        public int Area { get; set; }

        public WarehouseLocation Location { get; set; }


        [Display(Name = "Number of Workers")]
        public int NoOfWorkers { get; set; }




        //site dropdown
        public int SectorId { get; set; }
        public List<Sector> Sectors { get; set; }
    }
}
