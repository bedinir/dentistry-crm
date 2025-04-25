using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IDentistryService
    {
        Task<IEnumerable<DentistDto>> GetAllDentists(bool trackChanges);
        Task<DentistDto> GetDentist(Guid dentistId, bool trackChanges);
        Task<DentistDto> CreateDentist(CreateDentistDto dentist);
        Task<DentistDto> UpdateDentist(Guid dentistId, DentistForUpdateDto dentistForUpdate, bool trackChanges);
        Task<bool> DeleteDentist(Guid dentistId);
    }
}
