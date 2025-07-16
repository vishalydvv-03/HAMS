using HAMS.Domain.Models.DoctorModels;
using HAMS.Services.AppointmentServices;
using HAMS.Services.DoctorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService service;

        public DoctorController(IDoctorService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await service.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound("Doctor not found");
            }
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDoctor model)
        {
            var updated = await service.UpdateAsync(id, model);
            if (!updated)
            {
                return NotFound("Doctor not found");
            }
            return Ok("Doctor updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await service.DeleteAsync(id);
            {
                if (!deleted)
                {
                    return NotFound("Doctor not found");
                }
                return Ok("Doctor deleted successfully");
            }
        }

        [HttpGet("{doctorId:guid}/appointments")]
        public async Task<IActionResult> GetAppointments(Guid doctorId)
        {
            var data = await service.GetAppointmentByDoctorAsync(doctorId);
            return Ok(data);
        }
    } 
}
