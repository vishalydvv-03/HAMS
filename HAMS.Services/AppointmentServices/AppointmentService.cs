using HAMS.Data;
using HAMS.Domain.Entities;
using HAMS.Domain.Enums;
using HAMS.Domain.Models.AppointmentModels;
using HAMS.Utility.UtilityHelpers.Email;
using Microsoft.EntityFrameworkCore;


namespace HAMS.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HamsDbContext context;
        private readonly IEmailService emailService;
        public AppointmentService(HamsDbContext context, IEmailService emailService)
        {
            this.context = context;
            this.emailService = emailService;
        }
        public async Task<bool> BookAsync(AddAppointment model)
        {
            var patient = await context.Patients.FindAsync(model.PatientId);
            var doctor = await context.Doctors.FindAsync(model.DoctorId);

            if (patient == null || doctor == null)
            {
                return false;
            }
            var dt = model.AppointmentTime;
            var day = (WeekDay)dt.DayOfWeek;

            var schedule = await context.DoctorSchedules.FirstOrDefaultAsync(x => x.DoctorId == model.DoctorId && x.Day == day);

            if (schedule == null || schedule.IsOnLeave)
            {
                return false;
            }

            if (schedule.StartTime != null && (dt.TimeOfDay < schedule.StartTime || dt.TimeOfDay >= schedule.EndTime))
            {
                return false;
            }

            var isBooked = await context.Appointments.AnyAsync(x => x.DoctorId == model.DoctorId &&
            x.AppointmentTime == model.AppointmentTime && x.Status == AppointmentStatus.Scheduled);

            if (isBooked)
            {
                return false;
            }

            var appt = new Appointment()
            {
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                AppointmentTime = model.AppointmentTime,
                Status = AppointmentStatus.Scheduled,
            };

            await context.Appointments.AddAsync(appt);
            await context.SaveChangesAsync();

            var emailBody = $@"
            <h3>Appointment Confirmed</h3>
            <p>Dear {patient.PatientName},</p>
            <p>Your appointment with Dr. {doctor.DoctorName} has been scheduled on <strong>{model.AppointmentTime:dddd, MMMM dd yyyy hh:mm tt}</strong>.</p>
            <p>Have a nice day !</p>";

            await emailService.SendEmailAsync(patient.User.Email, "Appointment Confirmation", emailBody);

            return true;
        }


        public async Task<bool> CancelAsync(int id)
        {
            var appt = await context.Appointments.FindAsync(id);
            if (appt == null || appt.Status == AppointmentStatus.Cancelled)
            {
                return false;
            }
            appt.Status = AppointmentStatus.Cancelled;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RescheduleAsync(int id, RescheduleAppointment model)
        {
            var current = await context.Appointments.FindAsync(id);
            if (current == null || current.Status != AppointmentStatus.Scheduled) 
            { 
                return false;
            } 
            var add = await BookAsync(new AddAppointment
            {
                DoctorId = current.DoctorId,
                PatientId = current.PatientId,
                AppointmentTime = model.NewTime
            });

            if (!add)
            {
                return false;
            }

            current.Status = AppointmentStatus.Rescheduled;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CompleteAsync(int id)
        {
            var appt = await context.Appointments.FindAsync(id);
            if (appt == null || appt.Status != AppointmentStatus.Scheduled)
            {
                return false;
            }
            appt.Status = AppointmentStatus.Completed;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<ReadAppointment>> GetAllAppointmentsAsync()
        {
            var data = await context.Appointments
                        .Select(x => new ReadAppointment()
                        {
                            PatientName = x.Patient.PatientName,
                            DoctorName = x.Doctor.DoctorName,
                            AppointmentDate = x.AppointmentTime
                        }).ToListAsync();
            return data;
        }   
    }
}

