using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tct_Magazina.Interfaces;
using tct_Magazina.Models;
using tct_Magazina.ViewModels;

namespace tct_Magazina.Controllers
{
    [Authorize]
    public class WarehouseController : Controller
    {


        //inject warehouse repository
        public readonly AppDbContext _appDbContext;
        public readonly IWarehouseRepository _warehouseRepository;
        public readonly ISectorRepository _sectorRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository, AppDbContext appDbContext, ISectorRepository sectorRepository)
        {
            _warehouseRepository = warehouseRepository;
            _sectorRepository = sectorRepository;
            _appDbContext =appDbContext;
    }


        public IActionResult Index()
        {
            return View();
        }



        public ActionResult CreateWarehouse()
        {
            WarehouseViewModel warehouseViewModel = new WarehouseViewModel()
            {
                Sectors = _sectorRepository.allSectors()
            };

            return View(warehouseViewModel);
        }



        //krijimi i warehouse
        [HttpPost]
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
            return View(new WarehouseViewModel() { Sectors = _sectorRepository.allSectors() });
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








        //PROCESI I UPDATE 
        public ActionResult EditWarehouse(int id)
        {

            Warehouse mywarehouse =_warehouseRepository.GetWarehouseById(id);

            return View(mywarehouse);
        }



        public ActionResult EditConfirm(Warehouse newswarehouse)
        {
           _warehouseRepository.UpdateWarehouse(newswarehouse);

            _appDbContext.SaveChanges();

            return View();



        }


        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Warehouse> warehouses;

            if (string.IsNullOrEmpty(_searchString))
            {
                warehouses = _warehouseRepository.Warehouses.OrderBy(p => p.WarehouseId);
            }
            else
            {
                warehouses = _warehouseRepository.Warehouses.Where(p => p.Name.ToLower().Contains(_searchString.ToLower())).OrderBy(p=>p.Name);
            }

            return View("~/Views/Warehouse/List.cshtml", new WarehouseListViewModel { Warehouses = warehouses });
        }

    }
}