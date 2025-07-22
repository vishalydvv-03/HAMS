using HAMS.Data;
using HAMS.Domain.Entities;
using HAMS.Domain.Enums;
using HAMS.Domain.Models.AuthenticationModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace HAMS.Services.AuthenticationServices
{
    public class AuthService : IAuthService
    {
        private readonly HamsDbContext context;
        private readonly IPasswordHasher<User> hasher;

        public AuthService(HamsDbContext context, IPasswordHasher<User> hasher)
        {
            this.context = context;
            this.hasher = hasher;
        }

        public async Task<bool> RegisterPatientAsync(RegisterPatient model)
        {
            var userExists = await context.Users.AnyAsync(u => u.Email == model.Email || u.ContactNo == model.ContactNo);
            if (userExists)
            {
                return false;
            }

            var id = Guid.NewGuid();

            var user = new User
            {
                UserId = id,
                Email = model.Email,
                ContactNo = model.ContactNo,
                Role = UserRole.Patient,
                CreatedAt = DateTime.UtcNow,
                PasswordHash = hasher.HashPassword(null, model.Password)
            };

            var patient = new Patient
            {
                PatientId = id,         
                PatientName = model.PatientName,
                Gender = model.Gender,
                BloodGroup = model.BloodGroup,
                Address = model.Address,
                DOB = model.DOB
            };

            context.Users.Add(user);
            context.Patients.Add(patient);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RegisterDoctorAsync(RegisterDoctor model)
        {
            var userExists = await context.Users.AnyAsync(u => u.Email == model.Email || u.ContactNo == model.ContactNo);
            if (userExists)
            {
                return false;
            }
            var deptExists = await context.Departments.AnyAsync(d => d.DepartmentId == model.DepartmentId );
            if (!deptExists)
            {
                return false;
            }

            var id = Guid.NewGuid();

            var user = new User
            {
                UserId = id,
                Email = model.Email,
                ContactNo = model.ContactNo,
                Role = UserRole.Doctor,
                CreatedAt = DateTime.UtcNow,
                PasswordHash = hasher.HashPassword(null, model.Password)
            };

            var doctor = new Doctor
            {
                DoctorId = id,
                DoctorName = model.DoctorName,
                Specialization = model.Specialization,
                DepartmentId = model.DepartmentId
            };

            context.Users.Add(user);
            context.Doctors.Add(doctor);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<User?> ValidateCredentialsAsync(UserLogin model)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                return null;
            } 

            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (result != PasswordVerificationResult.Success)
            {
                return null;
            }
            return user;
        }
    }
}

