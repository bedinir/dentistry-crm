using Contracts;
using Entities.Models;

namespace Repository
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Patient> GetAllPatients(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(p => p.FirstName)
                .ToList();
        public Patient GetPatient(Guid patientId, bool trackChanges) =>
            FindByCondition(p => p.PatientId.Equals(patientId), trackChanges)
                .SingleOrDefault();
        public void CreatePatient(Patient patient) => Create(patient);
        public void UpdatePatient(Patient patient) => Update(patient);
        public void DeletePatient(Patient patient) => Delete(patient);
    }
}
