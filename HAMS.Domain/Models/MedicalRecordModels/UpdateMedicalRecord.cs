using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Domain.Models.MedicalRecordModels
{
    public class UpdateMedicalRecord
    {
        public string VisitNotes { get; set; }
        public string Prescription { get; set; }
        public string FollowUpInstructions { get; set; }
    }
}
