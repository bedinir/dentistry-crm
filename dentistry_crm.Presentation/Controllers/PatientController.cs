using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace dentistry_crm.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PatientController(IServiceManager service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto patient)
        {
            if (patient == null)
                return BadRequest("Patient object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var createdPatient = await _service.PatientService.CreatePatient(patient);
            return CreatedAtRoute("PatientById", new { id = createdPatient.PatientId }, createdPatient);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _service.PatientService.GetAllPatients(trackChanges: false);
            return Ok(patients);
        }

        [HttpGet("{id:guid}", Name = "PatientById")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var patient = await _service.PatientService.GetPatient(id, trackChanges: false);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var patient = await _service.PatientService.GetPatient(id, trackChanges: false);
            if (patient == null)
                return NotFound();
            await _service.PatientService.DeletePatient(id);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] UpdatePatientDto patient)
        {
            if (patient == null)
                return BadRequest("Patient object is null");
            var updatedPatient = await _service.PatientService.UpdatePatient(id, patient, trackChanges: true);
            if (updatedPatient == null)
                return NotFound();
            return Ok(updatedPatient);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PatchPatient(Guid id, [FromBody] JsonPatchDocument<UpdatePatientDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("Patch document is null");

            var patientEntity = await _service.PatientService.GetPatientForPatch(id, trackChanges: true);
            
            patchDoc.ApplyTo(patientEntity.patientToPatch);

            _service.PatientService.SaveChangesForPatch(patientEntity.patientEntity, patientEntity.patientToPatch);
            return NoContent();
        }
    }
}
