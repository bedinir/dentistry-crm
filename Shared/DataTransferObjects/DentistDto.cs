using AutoMapper;
using Entities.Models;
using Service.Contracts;

namespace Shared.DataTransferObjects
{
    public record DentistDto : IMapFrom<Dentist>
    {
        public Guid DentistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dentist, DentistDto>();
        }
    }
}
