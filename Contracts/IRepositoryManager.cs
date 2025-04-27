using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IDentistryRepository Dentistry { get; }
        IPatientRepository Patient { get; }
        Task SaveAsync();
    }
}
