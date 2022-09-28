using ContosEMS.Data;
using ContosEMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Repositories
{
    public class EquipmentRepository
    {
        private EMSDbContext _context;
        public EquipmentRepository(EMSDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Equipment> All()
        {
            return this._context.Equipments;
        }

        public IEnumerable<Equipment> AllEquipments()
        {
            return this._context.Equipments.Where(eq => eq.Type.Equals("equipment"));
        }

        public IEnumerable<Equipment> AllLocations()
        {
            return this._context.Equipments.Where(eq => eq.Type.Equals("location"));
        }

        public Equipment GetEquipmentById(int id)
        {
            return this._context.Equipments.First(eq => eq.Id.Equals(id));
        }

        public IEnumerable<Equipment> GetEquipmentByManufacturer(string manufacturer)
        {
            return this._context.Equipments.Where(eq => eq.Manufacturer.Equals(manufacturer));
        }

        public IEnumerable<Equipment> GetEquipmentsDueThisMonth()
        {
            return this._context.Equipments.Where(eq => (eq.ServiceDueDate.Month == DateTime.Now.Month && eq.ServiceDueDate.Year == DateTime.Now.Year));
        }

        public string AddEquipment(Equipment equipment)
        {
            this._context.Equipments.Add(equipment);
            this._context.SaveChanges();
            return "Equipment Added successfully.";
        }

        public string UpdateEquipment(Equipment equipment)
        {
            var equipmentToUpdate = this._context.Equipments.First(eq => eq.Id.Equals(equipment.Id));
            equipmentToUpdate.Name = equipment.Name;
            equipmentToUpdate.Description = equipment.Description;
            equipmentToUpdate.InstalledDate = equipment.InstalledDate;
            equipmentToUpdate.ServiceDueDate = equipment.ServiceDueDate;
            equipmentToUpdate.Manufacturer = equipment.Manufacturer;
            equipmentToUpdate.Model = equipment.Model;
            equipmentToUpdate.Temperature = equipment.Temperature;
            equipmentToUpdate.AngularVelocity = equipment.AngularVelocity;
            equipmentToUpdate.Pressure = equipment.Pressure;
            equipmentToUpdate.Type = equipment.Type;
            equipmentToUpdate.ImageLink = equipment.ImageLink;
            this._context.SaveChanges();
            return "Equipment updated successfully.";
        }

        public string DeleteEquipment(int id)
        {
            this._context.Equipments.Remove(this._context.Equipments.First(eq => eq.Id.Equals(id)));
            this._context.SaveChanges();
            return "Equipment deleted succesfully.";
        }
    }
}
