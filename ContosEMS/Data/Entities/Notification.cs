using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data.Entities
{
    public class Notification
    {
        [ForeignKey("Technician")]
        public int TechnicianId { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        public string Title { get; set; }

        public int Severity { get; set; }

        public string Comments { get; set; }

        [Key]
        public DateTime Timestamp { get; set; }
    }
}
