using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(p => p.FirstName)
                .ToListAsync();
        public async Task<Patient> GetPatientAsync(Guid patientId, bool trackChanges) =>
            await FindByCondition(p => p.PatientId.Equals(patientId), trackChanges)
                .SingleOrDefaultAsync();
        public void CreatePatient(Patient patient) => Create(patient);
        public void UpdatePatient(Patient patient) => Update(patient);
        public void DeletePatient(Patient patient) => Delete(patient);
    }
}
