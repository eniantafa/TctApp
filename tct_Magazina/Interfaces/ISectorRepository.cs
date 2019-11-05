using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Models;
using tct_Magazina.ViewModels;

namespace tct_Magazina.Interfaces
{
    public interface ISectorRepository
    {

        List<Sector> allSectors();
        void CreateSector(SectorViewModel sectorViewModel);
        bool Exists(int sectorId);
        Sector GetSectorById(int sectorId);
        void Delete(int sectorId);
    }
}
