using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients"); // Table name

            builder.HasKey(p => p.PatientId); // Primary Key
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100).IsRequired(false);
            builder.HasIndex(p => p.Email).IsUnique(); // Unique constraint
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Address).HasMaxLength(200);
        }
    }
}
