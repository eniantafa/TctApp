using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Models;

namespace tct_Magazina.ViewModels
{
    public class WarehouseViewModel
    {

        [Key]
        public int WarehouseId { get; set; }
        [Required]
        public string Name { get; set; }

        public int Area { get; set; }

        public string Location { get; set; }


        [Display(Name = "Number of Workers")]
        public int NoOfWorkers { get; set; }




        //site dropdown
        public int SectorSectorId { get; set; }
        public List<Sector> Sectors { get; set; }
    }
}
