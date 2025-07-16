using HAMS.Data;
using HAMS.Domain.Entities;
using HAMS.Domain.Enums;
using HAMS.Domain.Models.DoctorScheduleModels;
using Microsoft.EntityFrameworkCore;

namespace HAMS.Services.DoctorScheduleServices
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly HamsDbContext context;

        public DoctorScheduleService(HamsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ReadDoctorSchedule>> GetSchedulesByDoctorIdAsync(Guid doctorId)
        {
            var data = await context.DoctorSchedules
                                    .Include(d => d.Doctor).ThenInclude(s => s.Department)
                                    .Where(x=>x.DoctorId==doctorId)
                                    .Select(x => new ReadDoctorSchedule()
                                    {
                                        DoctorName = x.Doctor.DoctorName,
                                        DepartmentName = x.Doctor.Department.DeptName,
                                        Day = x.Day,
                                        StartTime = x.StartTime,
                                        EndTime = x.EndTime,
                                        IsOnLeave = x.IsOnLeave
                                    }).ToListAsync();
            return data;
                
        }

        public async Task<bool> AddScheduleAsync(AddDoctorSchedule model)
        {
            var schedule = await context.DoctorSchedules.FirstOrDefaultAsync(s => s.DoctorId == model.DoctorId && s.Day == model.Day);

            if (schedule != null)
            {
                return false;
            }

            var newSchedule = new DoctorSchedule
            {
                DoctorId = model.DoctorId,
                Day = model.Day,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                IsOnLeave = model.IsOnLeave
            };

            context.DoctorSchedules.Add(newSchedule);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateScheduleAsync(Guid doctorId, WeekDay day, UpdateDoctorSchedule model)
        {
            var schedule = await context.DoctorSchedules.FirstOrDefaultAsync(s => s.DoctorId == doctorId && s.Day == day);

            if (schedule == null) 
            {
                return false;
            }

            schedule.StartTime = model.StartTime;
            schedule.EndTime = model.EndTime;
            schedule.IsOnLeave = model.IsOnLeave;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteScheduleAsync(Guid doctorId, WeekDay day)
        {
            var schedule = await context.DoctorSchedules.FirstOrDefaultAsync(s => s.DoctorId == doctorId && s.Day == day);

            if (schedule == null)
            {
                return false;
            }
            context.DoctorSchedules.Remove(schedule);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
