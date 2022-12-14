using ContosEMS.Data;
using ContosEMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Repositories
{
    public class PlantAdminRepository
    {
        private EMSDbContext _context;
        public PlantAdminRepository(EMSDbContext context)
        {
            this._context = context;
        }

        public bool CanPlantAdminRegister(PlantAdmin plantAdmin)
        {
            return !this._context.PlantAdmins.Any(t => t.Email == plantAdmin.Email);
        }

        public bool DoesPlantAdminExists(PlantAdmin plantAdmin)
        {
            return !this.CanPlantAdminRegister(plantAdmin);
        }

        public string RegisterPlantAdmin(PlantAdmin plantAdmin)
        {
            if (!this.CanPlantAdminRegister(plantAdmin))
            {
                return "Error: PlantAdmin already Registered.";
            }
            this._context.PlantAdmins.Add(plantAdmin);
            this._context.SaveChanges();
            return "Registered PlantAdmin successfully";
        }

        public string LoginPlantAdmin(PlantAdmin plantAdmin)
        {
            if (!this.DoesPlantAdminExists(plantAdmin))
            {
                return "Error: PlantAdmin does not exist";
            }
            if (this._context.PlantAdmins.Any(t => t.HashedPassword.Equals(plantAdmin.HashedPassword)))
            {
                return "Logged in PlantAdmin successfully";
            }
            else
            {
                return "Error: Wrong Password";
            }
        }

        public PlantAdmin GetPlantAdminByEmail(string email)
        {
            return this._context.PlantAdmins.First(t => t.Email.Equals(email));
        }

        public string LogoutPlantAdmin(string email)
        {
            UserManager.LogoutPlantAdmin(email);
            return "Logged out successfully.";
        }
    }
}
