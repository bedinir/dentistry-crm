using Contracts;
using Entities.Models;

namespace Repository
{
    public class DentistryRepository : RepositoryBase<Dentist>, IDentistryRepository
    {
        public DentistryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Dentist> GetAllDentists(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(d => d.LastName)
                .ToList();
        public Dentist GetDentist(Guid dentistId, bool trackChanges) =>
            FindByCondition(d => d.DentistId.Equals(dentistId), trackChanges)
                .SingleOrDefault();
        public void CreateDentist(Dentist dentist) => Create(dentist);
        public void UpdateDentist(Dentist dentist) => Update(dentist);
        public void DeleteDentist(Dentist dentist) => Delete(dentist);

        public bool IsDentistAvailable(Guid dentistId, DateTime date)
        {
            var dentist = FindByCondition(d => d.DentistId.Equals(dentistId), false)
                .SingleOrDefault();
            if (dentist == null)
                return false;
            // Check if the dentist is available on the given date
            // This is a placeholder implementation. You would need to implement the actual logic.
            return true;
        }
    }
}
