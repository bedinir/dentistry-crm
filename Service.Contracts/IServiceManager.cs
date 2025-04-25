using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IDentistryService DentistryService { get; }
        IPatientService PatientService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
