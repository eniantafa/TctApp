using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tct_Magazina.ViewModels
{
    public class SectorViewModel
    {

        public int SectorId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
