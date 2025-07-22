using HAMS.Data;
using HAMS.Domain.Entities;
using HAMS.Domain.Enums;
using HAMS.Domain.Models.MedicalRecordModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Services.MedicalRecordServices
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly HamsDbContext context;
        public MedicalRecordService(HamsDbContext context)
        { 
            this.context = context;
        }

        public async Task<bool> AddAsync(AddMedicalRecord model)
        {
            var appt = await context.Appointments.Include(a => a.Patient)
                                                 .Include(a => a.Doctor)
                                                 .FirstOrDefaultAsync(a => a.AppointmentId == model.AppointmentId);

            if (appt == null || appt.Status != AppointmentStatus.Completed) 
            {
                return false;
            }

            bool exists = await context.MedicalRecords.AnyAsync(r => r.AppointmentId == model.AppointmentId);
            if (exists)
            {
                return false;
            }

            var record = new MedicalRecord()
                        {
                            AppointmentId = model.AppointmentId,
                            VisitNotes = model.VisitNotes,
                            Prescription = model.Prescription,
                            FollowUpInstructions = model.FollowUpInstructions
                        };
            await context.MedicalRecords.AddAsync(record);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateMedicalRecord model)
        {
            var record = await context.MedicalRecords.FindAsync(id);
            if (record == null)
            {
                return false;
            }
            record.VisitNotes = model.VisitNotes;
            record.Prescription = model.Prescription;
            record.FollowUpInstructions = model.FollowUpInstructions;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rec = await context.MedicalRecords.FindAsync(id);
            if (rec == null)
            {
                return false;
            }
            context.MedicalRecords.Remove(rec);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<ReadMedicalRecord>> GetAllAsync()
        {
            var data = await context.MedicalRecords
                .Include(r => r.Appointment).ThenInclude(a => a.Patient)
                .Include(r => r.Appointment).ThenInclude(a => a.Doctor)
                .Select(r => new ReadMedicalRecord()
                {
                    RecordId = r.RecordId,
                    AppointmentId = r.AppointmentId,
                    PatientId = r.Appointment.PatientId,
                    PatientName = r.Appointment.Patient.PatientName,
                    DoctorName = r.Appointment.Doctor.DoctorName,
                    AppointmentTime = r.Appointment.AppointmentTime,
                    VisitNotes = r.VisitNotes,
                    Prescription = r.Prescription,
                    FollowUpInstructions = r.FollowUpInstructions,
                    CreatedAt = r.CreatedAt
                }).ToListAsync();
            return data;
        }
    }
}
