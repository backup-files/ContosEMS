using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data.Entities
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(1000)]
        public string Description { get; set; }

        public String InstalledDate { get; set; }

        public String ServiceDueDate { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(100)]
        public string Model { get; set; }
        
        public decimal Temperature { get; set; }

        public decimal AngularVelocity { get; set; }

        public decimal Pressure { get; set; }

        // "location" or "equipment"
        public string Type { get; set; }

        public string ImageLink { get; set; }
    }
}
