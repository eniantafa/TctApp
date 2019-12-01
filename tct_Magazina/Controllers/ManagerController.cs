using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tct_Magazina.Interfaces;
using tct_Magazina.Models;
using tct_Magazina.Repositories;
using tct_Magazina.ViewModels;

namespace tct_Magazina.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {

       // public readonly AppDbContext _appDbContext;

        public readonly IManagerRepository _managerRepository;

        public ManagerController(IManagerRepository managerRepository, AppDbContext appDbContext)
        {
            _managerRepository = managerRepository;
          //  _appDbContext = appDbContext;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult CreateManager(ManagerViewModel managerViewModel)
        {

            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Sector Error");

                return View();
            }


            _managerRepository.CreateManager(managerViewModel);
       

            return View();
            
            
        }

        



        public ActionResult GetAllManagers()
        {

            List<Manager> managers = _managerRepository.allManagers();
             return View(managers);
            
        }




        public ActionResult Delete(int id)
        {
            if (id == null)
            {

                return RedirectToAction("GetAllManagers");
            }

            if (!(_managerRepository.Exists(id)))
            {
                return RedirectToAction("GetAllManagers");

            }

            //USING LINQ

            return View(_managerRepository.GetManagerById(id));
        }



        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm (int id)
        {

            _managerRepository.Delete(id);

            return RedirectToAction("GetAllManagers");

        }







        //Edit

       


        public ActionResult EditManager(int id)
        {
            Manager mymanager = _managerRepository.GetManagerById(id);

            return View(mymanager);

        }

        public ActionResult EditConfirm (Manager newManager)
        {
            _managerRepository.UpdateManager(newManager);

            return View();

        }




        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Manager> managers;

            if (string.IsNullOrEmpty(_searchString))
            {
                managers = _managerRepository.Managers.OrderBy(p => p.ManagerId);
            }
            else
            {
                managers = _managerRepository.Managers.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Manager/List.cshtml", new ManagerListViewModel { Managers = managers});
        }

       
      

    }
}