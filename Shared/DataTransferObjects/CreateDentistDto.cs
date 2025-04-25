using Entities.Models;
using System.ComponentModel.DataAnnotations;

using Service.Contracts;
using AutoMapper;

namespace Shared.DataTransferObjects
{
    public record CreateDentistDto : IMapFrom<Dentist>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; init; }

        [Required]
        [MaxLength(50)]
        public string Specialization { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; init; }

        public string Role { get; init; } = "Dentist";

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dentist, CreateDentistDto>().ReverseMap();
        }
    }

}
