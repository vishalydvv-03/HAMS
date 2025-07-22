using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Domain.Models.Doctor
{
    public class ReadDoctor
    {
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }

    }
}
