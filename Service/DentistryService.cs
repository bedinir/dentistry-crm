using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Entities.Exceptions;

namespace Service
{
    internal sealed class DentistryService : IDentistryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public DentistryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DentistDto>> GetAllDentistsAsync(bool trackChanges)
        {
            try
            {
                var dentists = await _repository.Dentistry.GetAllDentistsAsync(trackChanges);
                var dentistDtos = _mapper.Map<IEnumerable<DentistDto>>(dentists);
                return dentistDtos;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong in the {nameof(GetAllDentistsAsync)} action: {ex.Message}");
                throw;
            }
        }
        public async Task<DentistDto> GetDentistAsync(Guid dentistId, bool trackChanges)
        {
            var dentist = await _repository.Dentistry.GetDentistAsync(dentistId, trackChanges);
            if (dentist is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Dentist>(dentistId));

            var dentistDto = _mapper.Map<DentistDto>(dentist);
            return dentistDto;
        }
        public async Task<DentistDto> CreateDentistAsync(CreateDentistDto dentist)
        {
            var dentistEntity = _mapper.Map<Dentist>(dentist);
            _repository.Dentistry.CreateDentist(dentistEntity);
            await _repository.SaveAsync();

            return _mapper.Map<DentistDto>(dentistEntity);
        }

        public async Task<DentistDto> UpdateDentistAsync(Guid dentistId, DentistForUpdateDto dentistForUpdate, bool trackChanges)
        {
            var dentistEntity = await _repository.Dentistry.GetDentistAsync(dentistId, trackChanges);
            if (dentistEntity is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Dentist>(dentistId));

            _mapper.Map(dentistForUpdate, dentistEntity);
            _repository.Dentistry.UpdateDentist(dentistEntity);
            await _repository.SaveAsync();

            return _mapper.Map<DentistDto>(dentistEntity);
        }

        public async Task<bool> DeleteDentistAsync(Guid dentistId)
        {
            var dentist = await _repository.Dentistry.GetDentistAsync(dentistId, trackChanges: false);
            if (dentist is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Dentist>(dentistId));

            _repository.Dentistry.DeleteDentist(dentist);
            await _repository.SaveAsync();
            return true;
        }
    }
}
