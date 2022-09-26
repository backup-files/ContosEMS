using ContosEMS.Data.Entities;
using System;
using System.Linq;

namespace ContosEMS.Data
{
    public static class InitializeData
    {
        public static void Seed(this EMSDbContext context)
        {
            if (!context.Equipments.Any())
            {
                AddEquipments(context);
            }

            if(!context.Technicians.Any())
            {
                AddTechnicians(context);
            }

            if (!context.PlantAdmins.Any())
            {
                AddPlantAdmins(context);
            }

            if (!context.Notifications.Any())
            {
                AddNotifications(context);
            }

            context.SaveChanges();
        }

        private static void AddNotifications(EMSDbContext context)
        {
            context.Notifications.Add(new Notification
            {
                TechnicianId = 1,
                EquipmentId = 1,
                Title = "AA",
                Severity = 1,
                Comments = "BB",
                Timestamp = DateTime.Now
            });
        }

        private static void AddPlantAdmins(EMSDbContext context)
        {
            context.PlantAdmins.Add(new PlantAdmin
            {
                Email = "D",
                HashedPassword = "E",
                Name = "F"
            });
        }

        private static void AddTechnicians(EMSDbContext context)
        {
            context.Technicians.Add(new Technician
            {
                Email = "A",
                HashedPassword = "B",
                Name = "C"
            });
        }

        private static void AddEquipments(EMSDbContext context)
        {
            context.Equipments.Add(new Equipment
            {
                Name = "A",
                Description = "B",
                InstalledDate = DateTime.Parse("01-01-2022"),
                ServiceDueDate = DateTime.Parse("01-10-2022"),
                Manufacturer = "C",
                Model = "D",
                Temperature = 40.5M,
                AngularVelocity = 1000.0M,
                Pressure = 1.2M,
                Type = "equipment",
                ImageLink = "E"
            });
        }
    }
}
