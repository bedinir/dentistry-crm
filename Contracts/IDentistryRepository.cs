using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDentistryRepository
    {
        Task<IEnumerable<Dentist>> GetAllDentistsAsync(bool trackChanges);
        Task<Dentist> GetDentistAsync(Guid dentistId, bool trackChanges);
        void CreateDentist(Dentist dentist);
        void UpdateDentist(Dentist dentist);
        void DeleteDentist(Dentist dentist);
        Task<bool> IsDentistAvailableAsync(Guid dentistId, DateTime date);
    }
}
