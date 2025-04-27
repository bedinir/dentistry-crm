using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PatientService : IPatientService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PatientService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync(bool trackChanges)
        {
            try
            {
                var patients = await _repository.Patient.GetAllPatientsAsync(trackChanges);
                return _mapper.Map<IEnumerable<PatientDto>>(patients);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllPatientsAsync)} action: {ex.Message}");
                throw;
            }
        }
        public async Task<PatientDto> GetPatientAsync(Guid patientId, bool trackChanges)
        {
            var patient = await _repository.Patient.GetPatientAsync(patientId, trackChanges);
            if (patient is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Patient>(patientId));

            var patientDto = _mapper.Map<PatientDto>(patient);
            return patientDto;
        }
        public async Task<PatientDto> CreatePatientAsync(CreatePatientDto patient)
        {
            var patientEntity = _mapper.Map<Patient>(patient);

            _repository.Patient.CreatePatient(patientEntity);
            await _repository.SaveAsync();

            return _mapper.Map<PatientDto>(patientEntity);
        }
        public async Task<bool> DeletePatientAsync(Guid patientId)
        {
            var patient = await _repository.Patient.GetPatientAsync(patientId,trackChanges : false);
            if (patient is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Patient>(patientId));

            _repository.Patient.DeletePatient(patient);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<PatientDto> UpdatePatientAsync(Guid patientId, UpdatePatientDto patient, bool trackChanges)
        {
            var patientEntity = await _repository.Patient.GetPatientAsync(patientId, trackChanges);
            if (patientEntity is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Patient>(patientId));

            _mapper.Map(patient, patientEntity);
            _repository.Patient.UpdatePatient(patientEntity);
            await _repository.SaveAsync();

            return _mapper.Map<PatientDto>(patientEntity);
        }

        public async Task<(UpdatePatientDto patientToPatch, Patient patientEntity)> GetPatientForPatchAsync(Guid patientId, bool trackChanges)
        {
            var patient = await _repository.Patient.GetPatientAsync(patientId, trackChanges: true);
            if (patient is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Patient>(patientId));

            var patientToPatch = _mapper.Map<UpdatePatientDto>(patient);

            return (patientToPatch, patient);
        }

        public async void SaveChangesForPatchAsync(Patient patientEntity, UpdatePatientDto patientToPatch)
        {
            _mapper.Map(patientToPatch, patientEntity);
            await _repository.SaveAsync();
        }
    }
}
