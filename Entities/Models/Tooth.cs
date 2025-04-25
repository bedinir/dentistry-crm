using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Tooth
    {
        [Key]
        public int ToothNumber { get; set; } // e.g. 11-48 (FDI notation)

        [MaxLength(50)]
        public string Name { get; set; } // Optional: e.g. "Upper Left Molar"

    }
}
