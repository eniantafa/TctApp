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
    public class SectorController : Controller
    {

        //inject sector repository
        public readonly ISectorRepository _sectorRepository;
        public readonly AppDbContext _appDbContext;
        //constructor
        public SectorController(ISectorRepository sectorRepository, AppDbContext appDbContext)
        {
            _sectorRepository = sectorRepository;
            _appDbContext = appDbContext;
        }



        public ActionResult Index()
        {

            
            return View();
        }


        public ActionResult CreateSector(SectorViewModel sectorViewModel)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Sector Error");

                return View();
            }


            _sectorRepository.CreateSector(sectorViewModel);


            return View();
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

            Sector mysector = GetSectorById(id);

            return View(mysector);
        }

         

        public ActionResult EditConfirm(Sector newsector)
        {
            Sector oldsector = GetSectorById(newsector.SectorId);
            oldsector.Name = newsector.Name;
            oldsector.Description = newsector.Description;

            _appDbContext.SaveChanges();

            return View();



        }


    }
}