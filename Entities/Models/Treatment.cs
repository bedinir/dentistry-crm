using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Treatment
    {
        [Key]
        public Guid TreatmentId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? EstimatedDurationInMinutes { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdated { get; set; }

        public ICollection<AppointmentTreatment> AppointmentTreatments { get; set; } = new List<AppointmentTreatment>();
        public ICollection<DentistTreatment> DentistTreatments { get; set; } = new List<DentistTreatment>();
    }
}
