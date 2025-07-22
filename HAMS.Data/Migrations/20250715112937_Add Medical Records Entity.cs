using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HAMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicalRecordsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    VisitNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Prescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FollowUpInstructions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 7, 17, 45, 648, DateTimeKind.Utc).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 7, 17, 45, 648, DateTimeKind.Utc).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 7, 17, 45, 648, DateTimeKind.Utc).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 15, 7, 17, 45, 704, DateTimeKind.Utc).AddTicks(4208), "AQAAAAIAAYagAAAAEO2xRC5/5dniXvkhbxSY8JU31nQHQeg5psnki/I2Y2N6iazDAtdhW0aaszLl1xEoKQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 15, 7, 17, 45, 767, DateTimeKind.Utc).AddTicks(3548), "AQAAAAIAAYagAAAAEKwqXlR/7OM6KEPjVoyXtCHg9w5aricNiYI7khOZCdLiSctTRJjsk7lXIQoqbbiTTQ==" });
        }
    }
}
