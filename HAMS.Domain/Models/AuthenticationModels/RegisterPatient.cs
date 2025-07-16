
using System.ComponentModel.DataAnnotations;


namespace HAMS.Domain.Models.AuthenticationModel
{
    public class RegisterPatient
    {
        [Required, MaxLength(100)]
        public string PatientName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Required, StringLength(10, MinimumLength = 10)]
        public string ContactNo { get; set; }

        [Required, MaxLength(20)]
        public string Gender { get; set; }

        [Required, MaxLength(5)]
        public string BloodGroup { get; set; }

        [Required, MaxLength(50)]
        public string Address { get; set; }
        public DateOnly DOB { get; set; }
    }
}
