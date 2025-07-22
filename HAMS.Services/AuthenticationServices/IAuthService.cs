using HAMS.Domain.Entities;
using HAMS.Domain.Models.AuthenticationModel;


namespace HAMS.Services.AuthenticationServices
{
    public interface IAuthService
    {
        Task<bool> RegisterPatientAsync(RegisterPatient model);
        Task<bool> RegisterDoctorAsync(RegisterDoctor model);
        Task<User?> ValidateCredentialsAsync(UserLogin model);
    }
}
