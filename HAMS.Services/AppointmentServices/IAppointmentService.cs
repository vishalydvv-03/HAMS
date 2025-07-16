using HAMS.Domain.Models.AppointmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<bool> BookAsync(AddAppointment model);
        Task<bool> CancelAsync(int appointmentId);
        Task<bool> RescheduleAsync(int appointmentId, RescheduleAppointment model);
        Task<bool> CompleteAsync(int appointmentId);
        Task<IEnumerable<ReadAppointment>> GetAllAppointmentsAsync();
    }
}
