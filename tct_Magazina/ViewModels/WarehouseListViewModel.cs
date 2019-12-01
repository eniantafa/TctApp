using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Models;

namespace tct_Magazina.ViewModels
{
    public class WarehouseListViewModel
    {
        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}
