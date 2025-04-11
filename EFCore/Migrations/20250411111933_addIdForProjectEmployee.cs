using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addIdForProjectEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("28e3b8e6-e581-489d-b211-9329909d69fb"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d0400fe1-5496-4f46-a4f8-a3e773a56b35"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d7e43c08-74df-4b47-a424-fddb0de96273"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e964fff1-2443-4a4f-a0c5-1c8ffe8b8511"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Project_Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ebbf486-6f1e-4fac-9ae7-d0e8fcecebee"), "HR" },
                    { new Guid("82aa094f-862f-482b-8ea7-61af6fbf3ee4"), "Software Development " },
                    { new Guid("d8c9ca8a-d65e-4e87-95ba-b0e0fb465b7e"), "Finance" },
                    { new Guid("eeb165c7-03f2-4653-a49a-dd55cbf73588"), "Accountant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2ebbf486-6f1e-4fac-9ae7-d0e8fcecebee"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("82aa094f-862f-482b-8ea7-61af6fbf3ee4"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d8c9ca8a-d65e-4e87-95ba-b0e0fb465b7e"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("eeb165c7-03f2-4653-a49a-dd55cbf73588"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Project_Employees");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("28e3b8e6-e581-489d-b211-9329909d69fb"), "Finance" },
                    { new Guid("d0400fe1-5496-4f46-a4f8-a3e773a56b35"), "Software Development " },
                    { new Guid("d7e43c08-74df-4b47-a424-fddb0de96273"), "HR" },
                    { new Guid("e964fff1-2443-4a4f-a0c5-1c8ffe8b8511"), "Accountant" }
                });
        }
    }
}
