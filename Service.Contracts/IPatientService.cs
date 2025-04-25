using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatients(bool trackChanges);
        Task<PatientDto> GetPatient(Guid patientId, bool trackChanges);
        Task<PatientDto> CreatePatient(CreatePatientDto patient);
        Task<PatientDto> UpdatePatient(Guid patientId, UpdatePatientDto patient, bool trackChanges);
        Task<bool> DeletePatient(Guid patientId);
        Task<(UpdatePatientDto patientToPatch, Patient patientEntity)> GetPatientForPatch(Guid patientId, bool trackChanges);
        void SaveChangesForPatch(Patient patientEntity, UpdatePatientDto patientToPatch);
    }
}
