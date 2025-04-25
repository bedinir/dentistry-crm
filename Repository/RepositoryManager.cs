using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IDentistryRepository _dentistryRepository;
        private readonly Lazy<IPatientRepository> _patientRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _dentistryRepository = new Lazy<IDentistryRepository>(() => new DentistryRepository(_repositoryContext)).Value;
            _patientRepository = new Lazy<IPatientRepository>(() => new PatientRepository(_repositoryContext));
        }
        public IDentistryRepository Dentistry => _dentistryRepository;
        public IPatientRepository Patient => _patientRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }
}
