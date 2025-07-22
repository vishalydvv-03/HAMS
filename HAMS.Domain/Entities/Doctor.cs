using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HAMS.Domain.Entities
{
    public class Doctor
    {
        [Key, ForeignKey(nameof(User))]
        public Guid DoctorId { get; set; }
        public User User { get; set; }

        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<DoctorSchedule> Schedules { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    } 
}
