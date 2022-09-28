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
        [Key]
        public int Id { get; set; }

        [ForeignKey("Technician")]
        public int TechnicianEmail { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        public string Title { get; set; }

        public int Severity { get; set; }

        public string Comments { get; set; }

        public DateTime Timestamp { get; set; }

        public string Status { get; set; }
    }
}
