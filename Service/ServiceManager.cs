using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDentistryService> _dentistryService;
        private readonly Lazy<IPatientService> _patientService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _dentistryService = new Lazy<IDentistryService>(() => new DentistryService(repositoryManager, logger, mapper));
            _patientService = new Lazy<IPatientService>(() => new PatientService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager,logger, mapper,configuration));
        }

        public IDentistryService DentistryService => _dentistryService.Value;
        public IPatientService PatientService => _patientService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
