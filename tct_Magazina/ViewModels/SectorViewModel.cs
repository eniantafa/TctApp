using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Models;

namespace tct_Magazina.ViewModels
{
    public class SectorViewModel
    {


        [Key]
        public int SectorId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


        public int ManagerId { get; set; }
        public List<Manager> Managers { get; set; }

    }
}
