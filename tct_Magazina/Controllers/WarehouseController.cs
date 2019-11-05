using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tct_Magazina.Interfaces;
using tct_Magazina.Models;
using tct_Magazina.ViewModels;

namespace tct_Magazina.Controllers
{
    public class WarehouseController : Controller
    {


        //inject warehouse repository
        public readonly AppDbContext _appDbContext;
        public readonly IWarehouseRepository _warehouseRepository;
        public WarehouseController(IWarehouseRepository warehouseRepository, AppDbContext appDbContext)
        {
            _warehouseRepository = warehouseRepository;
            _appDbContext=appDbContext;
    }


        public IActionResult Index()
        {
            return View();
        }

        //krijimi i warehouse
        public ActionResult CreateWarehouse(WarehouseViewModel warehouseViewModel)
        {
            //kusht nqs modeli eshte valid

            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Warehouse Error");

                return View();
            }

            //ruajtja e te dhenave ne databaze
            _warehouseRepository.CreateWarehouse(warehouseViewModel);
            return View();
        }


       

        public ActionResult GetAllWarehouses()
        {

            List<Warehouse> warehouses = _warehouseRepository.allWarehouses();

            return View(warehouses);
        }




        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return RedirectToAction("GetAllWarehouses");

            }

            if (!(_warehouseRepository.Exists(id)))
            {
                return RedirectToAction("GetAllWarehouses");
            }
            return View(_warehouseRepository.GetWarehouseById(id));
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            _warehouseRepository.Delete(id);


            return RedirectToAction("GetAllWarehouses");

        }

    }
}