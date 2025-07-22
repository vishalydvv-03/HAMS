using HAMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HAMS.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required, StringLength(10,MinimumLength=10)]
        public string ContactNo { get; set; }

        [Required]
        public UserRole Role { get; set; } = UserRole.Patient;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
