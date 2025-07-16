using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Domain.Models.MedicalRecordModels
{
    public class ReadMedicalRecord
    {
        public int RecordId { get; set; }
        public int AppointmentId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string VisitNotes { get; set; }
        public string Prescription { get; set; }
        public string FollowUpInstructions { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
