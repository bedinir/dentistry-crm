using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AppointmentTreatment
    {
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public Guid TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
