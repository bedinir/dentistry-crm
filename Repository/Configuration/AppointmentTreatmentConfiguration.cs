using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class AppointmentTreatmentConfiguration : IEntityTypeConfiguration<AppointmentTreatment>
    {
        public void Configure(EntityTypeBuilder<AppointmentTreatment> builder)
        {
            builder.ToTable("AppointmentTreatments");
            builder.HasKey(at => new { at.AppointmentId, at.TreatmentId });

            builder.HasOne(at => at.Appointment)
                .WithMany(a => a.AppointmentTreatments)
                .HasForeignKey(at => at.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(at => at.Treatment)
                .WithMany(t => t.AppointmentTreatments)
                .HasForeignKey(at => at.TreatmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
