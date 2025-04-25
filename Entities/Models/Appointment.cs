using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Appointment
    {
        [Key]
        public Guid AppointmentId { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public Guid DentistId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public int? DurationInMinutes { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

        public bool IsFirstVisit { get; set; }

        [MaxLength(100)]
        public string? Room { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdated { get; set; }

        public string? CancelledReason { get; set; }

        // Navigation
        public Patient Patient { get; set; }
        public Dentist Dentist { get; set; }
        public ICollection<AppointmentTreatment> AppointmentTreatments { get; set; } = new List<AppointmentTreatment>();
        public ICollection<AppointmentTooth> TreatedTeeth { get; set; } = new List<AppointmentTooth>();
    }

}
