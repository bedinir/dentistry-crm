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
        public async Task<IEnumerable<PatientDto>> GetAllPatients(bool trackChanges)
        {
            try
            {
                var patients = _repository.Patient.GetAllPatients(trackChanges);
                return _mapper.Map<IEnumerable<PatientDto>>(patients);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllPatients)} action: {ex.Message}");
                throw;
            }
        }
        public async Task<PatientDto> GetPatient(Guid patientId, bool trackChanges)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges);
            if (patient is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Patient>(patientId));

            var patientDto = _mapper.Map<PatientDto>(patient);
            return patientDto;
        }
        public async Task<PatientDto> CreatePatient(CreatePatientDto patient)
        {
            var patientEntity = _mapper.Map<Patient>(patient);

            _repository.Patient.CreatePatient(patientEntity);
            _repository.Save();

            return _mapper.Map<PatientDto>(patientEntity);
        }
        public async Task<bool> DeletePatient(Guid patientId)
        {
            var patient = _repository.Patient.GetPatient(patientId,trackChanges : false);
            if (patient is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Patient>(patientId));

            _repository.Patient.DeletePatient(patient);
            _repository.Save();
            return true;
        }

        public async Task<PatientDto> UpdatePatient(Guid patientId, UpdatePatientDto patient, bool trackChanges)
        {
            var patientEntity = _repository.Patient.GetPatient(patientId, trackChanges);
            if (patientEntity is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Patient>(patientId));

            _mapper.Map(patient, patientEntity);
            _repository.Patient.UpdatePatient(patientEntity);
            _repository.Save();

            return _mapper.Map<PatientDto>(patientEntity);
        }

        public async Task<(UpdatePatientDto patientToPatch, Patient patientEntity)> GetPatientForPatch(Guid patientId, bool trackChanges)
        {
            var patient = _repository.Patient.GetPatient(patientId, trackChanges: true);
            if (patient is null)
                throw new NotFoundException(NotFoundException.GenerateMessage<Patient>(patientId));

            var patientToPatch = _mapper.Map<UpdatePatientDto>(patient);

            return (patientToPatch, patient);
        }

        public void SaveChangesForPatch(Patient patientEntity, UpdatePatientDto patientToPatch)
        {
            _mapper.Map(patientToPatch, patientEntity);
            _repository.Save();
        }
    }
}
