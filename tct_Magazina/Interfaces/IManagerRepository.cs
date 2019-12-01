using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Models;
using tct_Magazina.ViewModels;

namespace tct_Magazina.Interfaces
{
    public interface IManagerRepository
    {

        List<Manager> allManagers();
        void CreateManager(ManagerViewModel managerViewModel);
        bool Exists(int managerId);
        Manager GetManagerById(int managerId);
        void Delete(int managerId);
        void UpdateManager(Manager newmanager);
        IEnumerable<Manager> Managers { get; }

    }
}
