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
    public class AppointmentToothConfiguration : IEntityTypeConfiguration<AppointmentTooth>
    {
        public void Configure(EntityTypeBuilder<AppointmentTooth> builder)
        {
            builder.ToTable("AppointmentTooths");
            builder.HasKey(at => new { at.AppointmentId, at.ToothNumber });
            builder.Property(at => at.ProcedureDescription)
                .HasMaxLength(250);

            builder.HasOne(at => at.Appointment)
                .WithMany(a => a.TreatedTeeth)
                .HasForeignKey(at => at.AppointmentId);

            builder.HasOne(at => at.Tooth)
                .WithMany()
                .HasForeignKey(at => at.ToothNumber)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Tooth if it's referenced in AppointmentTooth
        }
    }
}
