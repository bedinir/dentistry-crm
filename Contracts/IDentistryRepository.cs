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
        IEnumerable<Dentist> GetAllDentists(bool trackChanges);
        Dentist GetDentist(Guid dentistId, bool trackChanges);
        void CreateDentist(Dentist dentist);
        void UpdateDentist(Dentist dentist);
        void DeleteDentist(Dentist dentist);
        bool IsDentistAvailable(Guid dentistId, DateTime date);
    }
}
