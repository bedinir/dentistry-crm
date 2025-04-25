using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CreatePatientDto : IMapFrom<Patient>
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; init; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string Gender { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public string Address { get; init; }

    }
}
