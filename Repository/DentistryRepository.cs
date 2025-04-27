using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DentistryRepository : RepositoryBase<Dentist>, IDentistryRepository
    {
        public DentistryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Dentist>> GetAllDentistsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(d => d.LastName)
                .ToListAsync();
        public async Task<Dentist> GetDentistAsync(Guid dentistId, bool trackChanges) =>
            await FindByCondition(d => d.DentistId.Equals(dentistId), trackChanges)
                .SingleOrDefaultAsync();
        public void CreateDentist(Dentist dentist) => Create(dentist);
        public void UpdateDentist(Dentist dentist) => Update(dentist);
        public void DeleteDentist(Dentist dentist) => Delete(dentist);

        public async Task<bool> IsDentistAvailableAsync(Guid dentistId, DateTime date)
        {
            var dentist = await FindByCondition(d => d.DentistId.Equals(dentistId), false)
                .SingleOrDefaultAsync();
            if (dentist == null)
                return false;
            // Check if the dentist is available on the given date
            // This is a placeholder implementation. You would need to implement the actual logic.
            return true;
        }
    }
}
