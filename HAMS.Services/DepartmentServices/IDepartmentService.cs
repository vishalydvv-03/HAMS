using HAMS.Domain.Entities;
using HAMS.Domain.Models.Department;
using HAMS.Domain.Models.DepartmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<IEnumerable<ReadDepartment>> GetAllDepartmentAsync();
        Task<ReadDepartment> GetDepartmentByIdAsync(int id);
        Task<bool> AddDepartmentAsync(AddDepartment dept);
        Task<bool> UpdateDepartmentAsync(int id, AddDepartment dept);
        Task<bool> DeleteDepartmentAsync(int id);

    }
}
