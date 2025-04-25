using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "3317fe00-c31a-4fbf-944a-20cc8a41082a",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "a211f43f-94df-4f2a-a88a-cbd1fe008e37",
                    Name = "Dentist",
                    NormalizedName = "DENTIST"
                },
                new IdentityRole
                {
                    Id = "c6eb899f-d3f5-4a2e-ae9d-b4c038ab69cf",
                    Name = "Patient",
                    NormalizedName = "PATIENT"
                }
            );
        }
    }
}
