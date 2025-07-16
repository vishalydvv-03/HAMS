using HAMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Data.Configurations
{
    public class MedicalRecordConfigurations : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasIndex(r => r.AppointmentId).IsUnique();

            builder.HasOne(a => a.Appointment)
                .WithOne(a => a.MedicalRecord)
                .HasForeignKey<MedicalRecord>(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
