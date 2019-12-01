using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Interfaces;
using tct_Magazina.Models;
using tct_Magazina.ViewModels;

namespace tct_Magazina.Repositories
{



    
    public class SectorRepository : ISectorRepository
    {



        public AppDbContext _appDbContext;
        public SectorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Sector> allSectors()
        {
            return _appDbContext.Sectors.ToList();
        }

        public void CreateSector(SectorViewModel sectorViewModel)
        {
            Sector sector = new Sector()
            {

                Name = sectorViewModel.Name,
                Description = sectorViewModel.Description,


                DateTimeCreated = DateTime.Now,
                DateTimeModified = DateTime.Now,

                ManagerId = sectorViewModel.ManagerId
            };



            _appDbContext.Sectors.Add(sector);
            _appDbContext.SaveChanges();
        }

        public void Delete(int sectorId)
        {
            Sector sector = _appDbContext.Sectors.Where(n => n.SectorId == sectorId).FirstOrDefault();
            _appDbContext.Sectors.Remove(sector);
            _appDbContext.SaveChanges();
        }

        public bool Exists(int sectorId)
        {
           return _appDbContext.Sectors.Any(n => n.SectorId == sectorId);
        }

        public Sector GetSectorById(int sectorId)
        {
            return _appDbContext.Sectors.Where(n => n.SectorId == sectorId).FirstOrDefault();
        }



        public void UpdateSector(Sector newsector)
        {
            Sector oldSector = GetSectorById(newsector.SectorId);
            oldSector.Name = newsector.Name;
            oldSector.Description = newsector.Description;
            
            oldSector.DateTimeModified = DateTime.Now;
            _appDbContext.SaveChanges();

        }



        public IEnumerable<Sector> Sectors => _appDbContext.Sectors;


    }
}
