using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosEMS.Data.Entities
{
    public class PlantAdmin
    {
        [Key]
        public string Email { get; set; }

        public string HashedPassword { get; set; }

        public string Name { get; set; }
    }
}
