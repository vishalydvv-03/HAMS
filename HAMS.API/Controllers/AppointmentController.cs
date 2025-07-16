using HAMS.Domain.Models.AppointmentModels;
using HAMS.Services.AppointmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace HAMS.API.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService service;
        public AppointmentController(IAppointmentService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment(AddAppointment model)
        {
            var result = await service.BookAsync(model);

            if (result == false)
            {
                return BadRequest("Could not Book Appointment");
            }

            return Ok("Appointment Booked Successfully");
        }

        [HttpPut("{id:int}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await service.CancelAsync(id);
            if (!result)
            {
                return NotFound("No Such Appointment");
            }

            return Ok("Appointment Cancelled Successfully");
        }
            
        [HttpPut("{id:int}/reschedule")]
        public async Task<IActionResult> Reschedule(int id, RescheduleAppointment model)
        {
            var result = await service.RescheduleAsync(id, model);
            if (!result)
            {
                return BadRequest("New Slot Unavailable");
            }

            return Ok("Appointment Rescheduled Successfully");
        }

        [HttpPut("{id:int}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await service.CompleteAsync(id);
            if (!result)
            {
                return NotFound("No Such Appointment");
            }

            return Ok("Appointment Marked as Completed");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var data = await service.GetAllAppointmentsAsync();
            return Ok(data);
        }
            
    }
}
