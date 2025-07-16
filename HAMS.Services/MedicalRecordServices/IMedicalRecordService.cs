using HAMS.Domain.Models.MedicalRecordModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Services.MedicalRecordServices
{
    public interface IMedicalRecordService
    {
        Task<bool> AddAsync(AddMedicalRecord model);
        Task<bool> UpdateAsync(int id, UpdateMedicalRecord model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ReadMedicalRecord>> GetAllAsync();

    }
}
