using HAMS.Domain.Entities;
using HAMS.Domain.Models.Doctor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Domain.Models.Department
{
    public class ReadDepartment
    {
        public int DepartmentId { get; set; }
        public string DeptName { get; set; }
        public string Description { get; set; }
        public ICollection<ReadDoctor> Doctors { get; set; } = new List<ReadDoctor>();
    }
}
