using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina;
using tct_Magazina.Interfaces;
using tct_Magazina.Models;
using tct_Magazina.ViewModels;

namespace tct_Magazina.Repositories
{
    public class ManagerRepository : IManagerRepository
    {


        public  AppDbContext _appDbContext;

        //dependency injection of appdbcontext
        public ManagerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //return list of managers
        public List<Manager> allManagers()
        {
            return _appDbContext.Managers.ToList();
        }


        //create manager
        public void CreateManager(ManagerViewModel managerViewModel)
        {
            Manager manager = new Manager()
            {
                Name = managerViewModel.Name,
                DateOfBirth = managerViewModel.DateOfBirth,
                email = managerViewModel.email,
                PhoneNumber = managerViewModel.PhoneNumber,


            DateTimeCreated = DateTime.Now,
                DateTimeModified = DateTime.Now,


                DefaultValue = "Henri"



            };



            _appDbContext.Managers.Add(manager);
            _appDbContext.SaveChanges();
        }



        public void Delete(int managerId)
        {

            Manager manager =  _appDbContext.Managers.Where(n => n.ManagerId == managerId).FirstOrDefault();
            _appDbContext.Managers.Remove(manager);
            _appDbContext.SaveChanges();
        }



        public bool Exists(int managerId)
        {
            return _appDbContext.Managers.Any(n => n.ManagerId == managerId);
        }



        public Manager GetManagerById(int managerId)
        {
            return _appDbContext.Managers.Where(n => n.ManagerId == managerId).FirstOrDefault();
        }

        public void UpdateManager(Manager newmanager)
        {
            Manager oldManager = GetManagerById(newmanager.ManagerId);
            oldManager.Name = newmanager.Name;
            oldManager.PhoneNumber = newmanager.PhoneNumber;
            oldManager.email = newmanager.email;
            oldManager.DateOfBirth = newmanager.DateOfBirth;
            oldManager.DateTimeModified = DateTime.Now;
            _appDbContext.SaveChanges();

        }


        public IEnumerable<Manager> Managers => _appDbContext.Managers;

    }
}
