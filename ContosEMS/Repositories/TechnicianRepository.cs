using ContosEMS.Data;
using ContosEMS.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Repositories
{
    public class TechnicianRepository
    {
        private EMSDbContext _context;

        public object SignInStatus { get; private set; }

        public TechnicianRepository(EMSDbContext context)
        {
            this._context = context;
        }

        public bool CanTechnicianRegister(Technician technician)
        {
            return !this._context.Technicians.Any(t => t.Email.Equals(technician.Email));
        }

        public bool DoesTechnicianExists(Technician technician)
        {
            return !this.CanTechnicianRegister(technician);
        }

        public string RegisterTechnician(Technician technician)
        {
            if (!this.CanTechnicianRegister(technician))
            {
                return "Error: Technician already Registered.";
            }
            this._context.Technicians.Add(technician);
            this._context.SaveChanges();
            return "Registered Technician successfully";
        }

        public string LoginTechnician(Technician technician)
        {
            if(!this.DoesTechnicianExists(technician))
            {
                return "Error: Technician does not exist";
            }
            if(this._context.Technicians.Any(t => t.HashedPassword.Equals(technician.HashedPassword)))
            {
                UserManager.LoginTechnician(technician.Email);
                return "Logged in Technician successfully";
            }
            else
            {
                return "Error: Wrong Password";
            }
        }

        public Technician GetTechnicianByEmail(string email)
        {
            return this._context.Technicians.First(t => t.Email.Equals(email));
        }

        public string LogoutTechnician(string email)
        {
            UserManager.LogoutTechnician(email);
            return "Logged out successfully.";
        }
    }
}
