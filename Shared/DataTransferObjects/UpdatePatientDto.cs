using AutoMapper;
using Entities.Models;
using Service.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record UpdatePatientDto : IMapFrom<Patient>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }


}
