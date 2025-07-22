using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HAMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 11, 55, 38, 957, DateTimeKind.Utc).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 11, 55, 38, 957, DateTimeKind.Utc).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 15, 11, 55, 38, 957, DateTimeKind.Utc).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 15, 11, 55, 39, 34, DateTimeKind.Utc).AddTicks(7537), "AQAAAAIAAYagAAAAEOwPrSxyCJGtlN9YeI93vzLuC2nnKmEe54mWFIJQ+jvmmWRhGk9SqcgYYBsvSG4t/g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 7, 15, 11, 55, 39, 117, DateTimeKind.Utc).AddTicks(1803), "AQAAAAIAAYagAAAAEBY3DIkiKF9vlK9/PzGAESLhlZK7elf/dpaiAmb1CPA4Ulr9YZhzvmVzWzXdW4VvBQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
