using HAMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Data.Seed
{
    internal class DepartmentSeed : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department()
                {
                    DepartmentId = 1,
                    DeptName = "Cardiology",
                    Description = "Heart & vascular care",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Department
                {
                    DepartmentId = 2,
                    DeptName = "Orthopedics",
                    Description = "Bones, joints & spine",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Department
                {
                    DepartmentId = 3,
                    DeptName = "Dermatology",
                    Description = "Skin & hair",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
  
        }
    }
}
