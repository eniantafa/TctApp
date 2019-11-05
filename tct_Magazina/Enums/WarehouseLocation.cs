using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tct_Magazina.Enums
{
    public enum WarehouseLocation
    {

        [Display(Name="Tirana")]
        Tirana,
        [Display(Name = "Elbasan")]
        Elbasan,
        [Display(Name = "Durres")]
        Durres,
        [Display(Name = "Kucove")]
        Kucove
    }
}
