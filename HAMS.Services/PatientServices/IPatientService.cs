using HAMS.Domain.Models.AppointmentModels;
using HAMS.Domain.Models.MedicalRecordModels;
using HAMS.Domain.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Services.PatientServices
{
    public interface IPatientService
    {
        Task<List<ReadPatient>> GetAllAsync();
        Task<ReadPatient> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, UpdatePatient model);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<ReadAppointmentByPatient>> GetAppointmentByPatientAsync(Guid patId);
        Task<IEnumerable<ReadMedicalRecordByPatient>> GetRecordsForPatientAsync(Guid patId);
        Task<IEnumerable<ReadPatient>> SearchPatientsAsync(string? name, string? email, string? mobile);

    }
}
