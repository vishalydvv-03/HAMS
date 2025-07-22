using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HAMS.Domain.Entities
{
    public class Patient
    {
        [Key,ForeignKey(nameof(User))]
        public Guid PatientId { get; set; }
        public User User { get; set; }

        [Required, MaxLength(100)]
        public string PatientName { get; set; }

        [Required, MaxLength(20)]
        public string Gender { get; set; }

        [Required, MaxLength(5)]
        public string BloodGroup { get; set; }

        [Required, MaxLength(50)]
        public string Address { get; set; }
        public DateOnly DOB { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
