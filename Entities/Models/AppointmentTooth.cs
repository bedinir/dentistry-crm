using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AppointmentTooth
    {
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public int ToothNumber { get; set; }
        public Tooth Tooth { get; set; }

        public string ProcedureDescription { get; set; }
    }
}
