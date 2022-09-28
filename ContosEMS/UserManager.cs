using ContosEMS.Data;
using ContosEMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS
{
    public static class UserManager
    {
        public static Dictionary<string, bool> IsLoggedIn { get; set; }
        public static Dictionary<string, bool> IsAdminLoggedIn { get; set; }

        public static void AddUsers(EMSDbContext context)
        {
            IsLoggedIn = new Dictionary<string, bool>();
            IsAdminLoggedIn = new Dictionary<string, bool>();
            foreach (var technician in context.Technicians)
            {
                IsLoggedIn.Add(technician.Email, false);
            }
            foreach(var plantAdmin in context.PlantAdmins)
            {
                IsLoggedIn.Add(plantAdmin.Email, false);
                IsAdminLoggedIn.Add(plantAdmin.Email, false);
            }
        }

        public static void LoginTechnician(string email)
        {
            IsLoggedIn[email] = true;
        }

        public static void LoginPlantAdmin(string email)
        {
            IsLoggedIn[email] = true;
            IsAdminLoggedIn[email] = true;
        }


        public static void LogoutTechnician(string email)
        {
            IsLoggedIn[email] = false;
        }

        public static void LogoutPlantAdmin(string email)
        {
            IsLoggedIn[email] = false;
            IsAdminLoggedIn[email] = false;
        }

    }
}
