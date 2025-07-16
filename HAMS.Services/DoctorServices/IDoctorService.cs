using HAMS.Domain.Models.AppointmentModels;
using HAMS.Domain.Models.Doctor;
using HAMS.Domain.Models.DoctorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<List<DoctorDetails>> GetAllAsync();
        Task<DoctorDetails> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, UpdateDoctor model);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<ReadAppointmentByDoctor>> GetAppointmentByDoctorAsync(Guid docId);
    }
}
