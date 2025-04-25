using AutoMapper;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record DentistForUpdateDto : IMapFrom<Dentist>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string Address { get; init; }
        public string Specialization { get; init; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DentistForUpdateDto, Dentist>();
        }
    }
}
