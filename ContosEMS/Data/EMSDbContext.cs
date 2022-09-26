using ContosEMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data
{
    public class EMSDbContext: DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options): base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Technician> Technicians { get; set; }

        public DbSet<PlantAdmin> PlantAdmins { get; set; }

        public DbSet<Notification> Notifications { get; set; }
    }
}
