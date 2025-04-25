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
        public async Task<IEnumerable<DentistDto>> GetAllDentists(bool trackChanges)
        {
            try
            {
                var dentists = _repository.Dentistry.GetAllDentists(trackChanges);
                var dentistDtos = _mapper.Map<IEnumerable<DentistDto>>(dentists);
                return dentistDtos;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong in the {nameof(GetAllDentists)} action: {ex.Message}");
                throw;
            }
        }
        public async Task<DentistDto> GetDentist(Guid dentistId, bool trackChanges)
        {
            var dentist = _repository.Dentistry.GetDentist(dentistId, trackChanges);
            if (dentist is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Dentist>(dentistId));

            var dentistDto = _mapper.Map<DentistDto>(dentist);
            return dentistDto;
        }
        public async Task<DentistDto> CreateDentist(CreateDentistDto dentist)
        {
            var dentistEntity = _mapper.Map<Dentist>(dentist);
            _repository.Dentistry.CreateDentist(dentistEntity);
            _repository.Save();

            return _mapper.Map<DentistDto>(dentistEntity);
        }

        public async Task<DentistDto> UpdateDentist(Guid dentistId, DentistForUpdateDto dentistForUpdate, bool trackChanges)
        {
            var dentistEntity = _repository.Dentistry.GetDentist(dentistId, trackChanges);
            if (dentistEntity is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Dentist>(dentistId));

            _mapper.Map(dentistForUpdate, dentistEntity);
            _repository.Dentistry.UpdateDentist(dentistEntity);
            _repository.Save();

            return _mapper.Map<DentistDto>(dentistEntity);
        }

        public async Task<bool> DeleteDentist(Guid dentistId)
        {
            var dentist = _repository.Dentistry.GetDentist(dentistId, trackChanges: false);
            if (dentist is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Dentist>(dentistId));

            _repository.Dentistry.DeleteDentist(dentist);
            _repository.Save();
            return true;
        }
    }
}
