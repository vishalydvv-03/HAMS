using HAMS.Domain.Models.AuthenticationModel;
using HAMS.Services.AuthenticationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        } 

        [HttpPost("register/patient")]
        public async Task<IActionResult> RegisterPatient(RegisterPatient model)
        {
            var result = await service.RegisterPatientAsync(model);
            if (result == false)
            {
                return BadRequest("Patient with this Email or Contact No. Already exists");
            }

            return Ok("Patient Registered Successfully");
        }
            

        [HttpPost("register/doctor")]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctor model)
        {
            var result = await service.RegisterDoctorAsync(model);
            if (result == false)
            {
                return BadRequest("Doctor with this Email or Contact No. already exists");
            }

            return Ok("Doctor Registered Successfully");
        }
            

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            var result= await service.ValidateCredentialsAsync(model);

            if (result == false)
            {
                return Unauthorized("Email or Password Entered Wrong");
            }

            return Ok("User Logged In Successfully");
        }
           
    }
}
