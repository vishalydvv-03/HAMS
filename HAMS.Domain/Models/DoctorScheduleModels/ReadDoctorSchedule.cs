using HAMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Domain.Models.DoctorScheduleModels
{
    public class ReadDoctorSchedule
    {
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public WeekDay Day { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsOnLeave { get; set; }
    }
}
