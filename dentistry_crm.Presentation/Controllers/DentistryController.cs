using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace dentistry_crm.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistryController : ControllerBase
    {
        private readonly IServiceManager _service;
        public DentistryController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllDentists()
        {
            var dentists = await _service.DentistryService.GetAllDentists(trackChanges: false);
            return Ok(dentists);
        }

        [HttpGet("{id:guid}", Name = "DentistById")]
        public async Task<IActionResult> GetDentist(Guid id)
        {
            var dentist = await _service.DentistryService.GetDentist(id, trackChanges: false);
            return Ok(dentist);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDentist([FromBody] CreateDentistDto dentist)
        {
            if (dentist == null)
                return BadRequest("Dentist object is null");

            var createdDentist = await _service.DentistryService.CreateDentist(dentist);
            return CreatedAtRoute("DentistById", new { id = createdDentist.DentistId }, createdDentist);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateDentist(Guid id, [FromBody] DentistForUpdateDto dentist)
        {
            if (dentist == null)
                return BadRequest("Dentist object is null");
            var dentistEntity = await _service.DentistryService.GetDentist(id, trackChanges: true);
            if (dentistEntity == null)
                return NotFound();
            await _service.DentistryService.UpdateDentist(id, dentist, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDentist(Guid id)
        {
            var dentist = await _service.DentistryService.GetDentist(id, trackChanges: false);
            if (dentist == null)
                return NotFound();
            await _service.DentistryService.DeleteDentist(id);
            return NoContent();
        }
    }
}
