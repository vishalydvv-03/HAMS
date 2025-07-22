using HAMS.Domain.Models.PatientModels;
using HAMS.Services.AppointmentServices;
using HAMS.Services.PatientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.API.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService service;

        public PatientController(IPatientService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await service.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound("Patient not found");
            }
            return Ok(data);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, UpdatePatient model)
        {
            var updated = await service.UpdateAsync(id, model);
            if (!updated) 
            {
                return NotFound("Patient not found");
            } 
            return Ok("Patient updated successfully");
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted) 
            {
                return NotFound("Patient not found");
            }
            return Ok("Patient deleted successfully");
        }

        [HttpGet("{patientId:guid}/appointments")]
        public async Task<IActionResult> GetAppointments(Guid patientId)
        {
            var data = await service.GetAppointmentByPatientAsync(patientId);
            return Ok(data);
        }

        [HttpGet("{patientId:guid}/medical-records")]
        public async Task<IActionResult> GetMedicalRecords(Guid patientId)
        {
            var data = await service.GetRecordsForPatientAsync(patientId);
            return Ok(data);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPatients([FromQuery] string? name, [FromQuery] string? email, [FromQuery] string? mobile)
        {
            var result = await service.SearchPatientsAsync(name, email, mobile);
            return Ok(result);
        }
    }

}
