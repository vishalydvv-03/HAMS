using HAMS.Data;
using HAMS.Domain.Entities;
using HAMS.Domain.Models.AppointmentModels;
using HAMS.Domain.Models.MedicalRecordModels;
using HAMS.Domain.Models.PatientModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly HamsDbContext context;
        public PatientService(HamsDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ReadPatient>> GetAllAsync()
        {
            return await context.Patients.Where(x=>x.User.IsActive)
                .Select(p => new ReadPatient
                {
                    PatientId = p.PatientId,
                    Name = p.PatientName,
                    Gender = p.Gender,
                    DateOfBirth = p.DOB,
                    Mobile = p.User.ContactNo,
                    Email = p.User.Email,
                    Address = p.Address,
                    BloodGroup = p.BloodGroup
                }).ToListAsync();
        }

        public async Task<ReadPatient> GetByIdAsync(Guid id)
        {
            var patient = await context.Patients.FirstOrDefaultAsync(x=>x.PatientId==id && x.User.IsActive);
            if (patient == null) 
            {
                return null;
            }

            return new ReadPatient
            {
                PatientId = patient.PatientId,
                Name = patient.PatientName,
                Gender = patient.Gender,
                DateOfBirth = patient.DOB,
                Mobile = patient.User.ContactNo,
                Email = patient.User.Email,
                Address = patient.Address,
                BloodGroup = patient.BloodGroup
            };
        }

        public async Task<bool> UpdateAsync(Guid id, UpdatePatient model)
        {
            var patient = await context.Patients.FirstOrDefaultAsync(x => x.PatientId == id && x.User.IsActive);
            if (patient == null)
            {
                return false;
            }

            patient.PatientName = model.Name;
            patient.Gender = model.Gender;
            patient.DOB = model.DateOfBirth;
            patient.User.ContactNo = model.Mobile;
            patient.User.Email = model.Email;
            patient.Address = model.Address;
            patient.BloodGroup = model.BloodGroup;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var patient = await context.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }

            patient.User.IsActive = false;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<ReadAppointmentByPatient>> GetAppointmentByPatientAsync(Guid patId)
        {
            var data = await context.Appointments
                        .Where(a => a.PatientId == patId && a.Patient.User.IsActive)
                        .Select(x => new ReadAppointmentByPatient()
                        {
                            DoctorName = x.Doctor.DoctorName,
                            AppointmentDate = x.AppointmentTime,
                            Status = x.Status,
                        }).ToListAsync();
            return data;
        }
        public async Task<IEnumerable<ReadMedicalRecordByPatient>> GetRecordsForPatientAsync(Guid patId)
        {
            var data = await context.MedicalRecords
                .Include(r => r.Appointment).ThenInclude(a => a.Patient)
                .Include(r => r.Appointment).ThenInclude(a => a.Doctor)
                .Where(r => r.Appointment.PatientId == patId)
                .Select(r => new ReadMedicalRecordByPatient()
                {
                    RecordId = r.RecordId,
                    AppointmentId = r.AppointmentId,
                    DoctorId = r.Appointment.DoctorId,
                    DoctorName = r.Appointment.Doctor.DoctorName,
                    AppointmentTime = r.Appointment.AppointmentTime,
                    VisitNotes = r.VisitNotes,
                    Prescription = r.Prescription,
                    FollowUpInstructions = r.FollowUpInstructions,
                    CreatedAt = r.CreatedAt
                }).ToListAsync();
            return data;
        }
        public async Task<IEnumerable<ReadPatient>> SearchPatientsAsync(string? name, string? email, string? mobile)
        {
            var query = context.Users.Include(x=>x.Patient).AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Patient.PatientName.Contains(name));

            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(p => p.Email.Contains(email));

            if (!string.IsNullOrWhiteSpace(mobile))
                query = query.Where(p => p.ContactNo.Contains(mobile));

            return await query.Select(p => new ReadPatient
            {
                PatientId = p.Patient.PatientId,
                Name = p.Patient.PatientName,
                Email = p.Email,
                Mobile = p.ContactNo,
                Gender = p.Patient.Gender,
                DateOfBirth = p.Patient.DOB,
                BloodGroup = p.Patient.BloodGroup,
                Address = p.Patient.Address
            }).ToListAsync();
        }

    }
}
