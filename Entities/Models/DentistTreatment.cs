using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DentistTreatment
    {
        public Guid DentistId { get; set; }
        public Dentist Dentist { get; set; }

        public Guid TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
