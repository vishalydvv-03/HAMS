
using System.ComponentModel.DataAnnotations;


namespace HAMS.Domain.Models.AuthenticationModel
{
    public class RegisterDoctor
    {
        [Required]
        public string DoctorName { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, StringLength(10, MinimumLength = 10)]
        public string ContactNo { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
