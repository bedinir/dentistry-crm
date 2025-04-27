using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync(bool trackChanges);
        Task<PatientDto> GetPatientAsync(Guid patientId, bool trackChanges);
        Task<PatientDto> CreatePatientAsync(CreatePatientDto patient);
        Task<PatientDto> UpdatePatientAsync(Guid patientId, UpdatePatientDto patient, bool trackChanges);
        Task<bool> DeletePatientAsync(Guid patientId);
        Task<(UpdatePatientDto patientToPatch, Patient patientEntity)> GetPatientForPatchAsync(Guid patientId, bool trackChanges);
        void SaveChangesForPatchAsync(Patient patientEntity, UpdatePatientDto patientToPatch);
    }
}
