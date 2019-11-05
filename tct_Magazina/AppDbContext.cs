using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tct_Magazina.Models;

namespace tct_Magazina
{
    public class AppDbContext:DbContext
    {

        private readonly IConfiguration _config;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) :base(options)
        {
            _config = config;
        }
        

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("tct_Magazina"));

        }


    }
}
