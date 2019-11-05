using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Models;
using tct_Magazina.ViewModels;

namespace tct_Magazina.Interfaces
{
   public interface IWarehouseRepository
    {

        List<Warehouse> allWarehouses();
        void CreateWarehouse(WarehouseViewModel warehouseViewModel);
        bool Exists(int warehouseId);
        Warehouse GetWarehouseById(int warehouseId);
        void Delete(int warehouseId);
    }
}
