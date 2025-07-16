using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Domain.Entities
{
    public class MedicalRecord
    {
        [Key]
        public int RecordId { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; }

        [Required, MaxLength(500)]
        public string VisitNotes { get; set; }

        [MaxLength(500)]
        public string Prescription { get; set; }

        [MaxLength(500)]
        public string FollowUpInstructions { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
