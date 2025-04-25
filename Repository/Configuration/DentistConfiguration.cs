using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class DentistConfiguration : IEntityTypeConfiguration<Dentist>
    {
        public void Configure(EntityTypeBuilder<Dentist> builder)
        {
            builder.ToTable("Dentists");

            builder.HasKey(d => d.DentistId);
            builder.Property(d => d.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.LastName).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Specialization).HasMaxLength(100);
            builder.Property(d => d.Email).HasMaxLength(100).IsRequired(false);
            builder.HasIndex(d => d.Email).IsUnique();
            builder.Property(d => d.Role).HasMaxLength(20).HasDefaultValue("Dentist");
        }
    }
}