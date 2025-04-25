using AutoMapper;
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
    public record UserForRegistrationDto : IMapFrom<User>
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Username is a required field.")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is a required field.")]
        public string? Password { get; init; }
        [Required(ErrorMessage = "Email is a required field.")]
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public ICollection<string>? Roles { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserForRegistrationDto,User>().ReverseMap();
        }
    }
}
