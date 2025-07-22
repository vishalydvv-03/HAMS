using System;
using HAMS.Domain.Entities;
using HAMS.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAMS.Data.Seed
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            var admin = new User { UserId = Guid.Parse("11111111-1111-1111-1111-111111111111") };
            var recep = new User { UserId = Guid.Parse("22222222-2222-2222-2222-222222222222") };

            builder.HasData(
                new User
                {
                    UserId = admin.UserId,
                    Email = "admin@hams.com",
                    PasswordHash = hasher.HashPassword(admin, "Admin@123"),
                    ContactNo = "9876543210",
                    Role = UserRole.Admin,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new User
                {
                    UserId = recep.UserId,
                    Email = "reception@hams.com",
                    PasswordHash = hasher.HashPassword(admin, "Recep@123"),
                    ContactNo = "9123456780",
                    Role = UserRole.Receptionist,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                });
        }
    }
}
