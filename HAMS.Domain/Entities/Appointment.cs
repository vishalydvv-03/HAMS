using HAMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }

        [Required]
        public DateTime AppointmentTime { get; set; }          

        [Required]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

        public MedicalRecord MedicalRecord { get; set; }

    }
}
