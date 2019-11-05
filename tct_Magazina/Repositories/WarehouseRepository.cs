using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Interfaces;
using tct_Magazina.Models;
using tct_Magazina.ViewModels;

namespace tct_Magazina.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {

        public readonly AppDbContext _appDbContext;

        public WarehouseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public List<Warehouse> allWarehouses()
        {
            return _appDbContext.Warehouses.ToList();

        }

        public void CreateWarehouse(WarehouseViewModel warehouseViewModel)
        {


            Warehouse warehouse = new Warehouse()
            {
                Name = warehouseViewModel.Name,
                Area = warehouseViewModel.Area,
                Location = warehouseViewModel.Location,
                NoOfWorkers = warehouseViewModel.NoOfWorkers,


              DateTimeCreated=DateTime.Now
            };


            _appDbContext.Warehouses.Add(warehouse);
            _appDbContext.SaveChanges();
        }

        public void Delete(int warehouseId)
        {
            Warehouse warehouse = _appDbContext.Warehouses.Where(n => n.WarehouseId == warehouseId).FirstOrDefault();
            _appDbContext.Warehouses.Remove(warehouse);
            _appDbContext.SaveChanges();
        }

        public bool Exists(int warehouseId)
        {
          return _appDbContext.Warehouses.Any(n => n.WarehouseId == warehouseId);
        }

        public Warehouse GetWarehouseById(int warehouseId)
        {
            return _appDbContext.Warehouses.Where(n => n.WarehouseId == warehouseId).FirstOrDefault();
        }
    }
}
