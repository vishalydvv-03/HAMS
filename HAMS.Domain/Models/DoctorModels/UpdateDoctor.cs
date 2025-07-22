using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Domain.Models.DoctorModels
{
    public class UpdateDoctor
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int DepartmentId { get; set; } 
        
    }
}
