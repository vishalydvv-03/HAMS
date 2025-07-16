
using System.ComponentModel.DataAnnotations;


namespace HAMS.Domain.Models.AuthenticationModel
{
    public class UserLogin
    {
        [EmailAddress, Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
