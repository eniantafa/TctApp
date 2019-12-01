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
    public class SectorController : Controller
    {

        //inject sector repository
        public readonly IManagerRepository _managerRepository;
        public readonly ISectorRepository _sectorRepository;
        public readonly AppDbContext _appDbContext;
        //constructor
        public SectorController(ISectorRepository sectorRepository, AppDbContext appDbContext, IManagerRepository managerRepository)
        {
            _sectorRepository = sectorRepository;
            _managerRepository = managerRepository;
            _appDbContext = appDbContext;
        }



        public ActionResult Index()
        {

            
            return View();
        }



        public ActionResult CreateSector()
        {
            SectorViewModel sectorViewModel = new SectorViewModel()
            {
                Managers = _managerRepository.allManagers()
            };

            return View(sectorViewModel);
        }


        [HttpPost]
        public ActionResult CreateSector(SectorViewModel sectorViewModel)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Sector Error");

                return View();
            }


            _sectorRepository.CreateSector(sectorViewModel);


            return View(new SectorViewModel() { Managers = _managerRepository.allManagers() });
        }


       


        public ActionResult GetAllSectors()
        {

            List<Sector> sectors = _sectorRepository.allSectors();
            return View(sectors);

        }


        public ActionResult Delete(int id)
        {
            if(id==null)
            {
                return RedirectToAction("GetAllSectors");

            }

            if (!(_sectorRepository.Exists(id)))

            {
                return RedirectToAction("GetAllSectors");
            }
            return View(_sectorRepository.GetSectorById(id));
        }


        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            _sectorRepository.Delete(id);


            return RedirectToAction("GetAllSectors");

        }



        public Sector GetSectorById(int sectorId)
        {

            return _appDbContext.Sectors.Where(n => n.SectorId == sectorId).FirstOrDefault();
        }


        //PROCESI I UPDATE 
        public ActionResult EditSector (int id)
        {

            Sector mysector = _sectorRepository.GetSectorById(id);

            return View(mysector);
        }

         

        public ActionResult EditConfirm(Sector newsector)
        {
            _sectorRepository.UpdateSector(newsector);

            _appDbContext.SaveChanges();

            return View();



        }



        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Sector> sectors;

            if (string.IsNullOrEmpty(_searchString))
            {
                sectors = _sectorRepository.Sectors.OrderBy(p => p.SectorId);
            }
            else
            {
                sectors = _sectorRepository.Sectors.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Sector/List.cshtml", new SectorListViewModel { Sectors = sectors });
        }

    }
}