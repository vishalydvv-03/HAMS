using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HAMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationPropertyOnAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_AppointmentId",
                table: "MedicalRecords");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 11, 42, 16, 952, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 11, 42, 16, 952, DateTimeKind.Utc).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 11, 42, 16, 952, DateTimeKind.Utc).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 15, 11, 42, 17, 27, DateTimeKind.Utc).AddTicks(9698), "AQAAAAIAAYagAAAAEMqmDroSqgHVUr56Il6k+8NDMIEIjyposmf0AdLr46RZckFWTV1pQE3kBwKv7TU0GQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 15, 11, 42, 17, 107, DateTimeKind.Utc).AddTicks(7278), "AQAAAAIAAYagAAAAEF2l1n8HMlTje6/JSowr6FcReMH6+E4uxZ3K/ofgfnC0FpWBNYRVaXrhMAIHulrKKA==" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AppointmentId",
                table: "MedicalRecords",
                column: "AppointmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_AppointmentId",
                table: "MedicalRecords");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 11, 29, 36, 938, DateTimeKind.Utc).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 11, 29, 36, 938, DateTimeKind.Utc).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 11, 29, 36, 938, DateTimeKind.Utc).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 15, 11, 29, 36, 999, DateTimeKind.Utc).AddTicks(7575), "AQAAAAIAAYagAAAAEKMPyJjrtDDppGQiHNUfl39MoAAfboJXP6rbDxVw+Yi6MOgjEDb0F421wsNwzMPeqg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 15, 11, 29, 37, 63, DateTimeKind.Utc).AddTicks(168), "AQAAAAIAAYagAAAAENmXvWm/CfMRTLVE21+03GVDfnYHHjUGkGfgDYXYRW6v+nCh+cHqwY9gpKw+O33gpg==" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AppointmentId",
                table: "MedicalRecords",
                column: "AppointmentId");
        }
    }
}
