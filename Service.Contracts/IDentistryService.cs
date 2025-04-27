using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IDentistryService
    {
        Task<IEnumerable<DentistDto>> GetAllDentistsAsync(bool trackChanges);
        Task<DentistDto> GetDentistAsync(Guid dentistId, bool trackChanges);
        Task<DentistDto> CreateDentistAsync(CreateDentistDto dentist);
        Task<DentistDto> UpdateDentistAsync(Guid dentistId, DentistForUpdateDto dentistForUpdate, bool trackChanges);
        Task<bool> DeleteDentistAsync(Guid dentistId);
    }
}
