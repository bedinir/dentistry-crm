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
    public class DentistTreatmentConfiguration : IEntityTypeConfiguration<DentistTreatment>
    {
        public void Configure(EntityTypeBuilder<DentistTreatment> builder)
        {
            builder.ToTable("DentistTreatments");
            builder.HasKey(dt => new { dt.DentistId, dt.TreatmentId });

            builder.HasOne(dt => dt.Dentist)
                .WithMany(d => d.DentistTreatments)
                .HasForeignKey(dt => dt.DentistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dt => dt.Treatment)
                .WithMany(t => t.DentistTreatments)
                .HasForeignKey(dt => dt.TreatmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
