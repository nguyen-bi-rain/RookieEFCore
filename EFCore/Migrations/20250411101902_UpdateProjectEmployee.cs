using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("0a9b0720-8187-4c8d-a7c5-e4417859db36"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("29995d04-aeeb-44a6-953f-bc5a8f320aec"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("63b33e78-af61-47bc-a1d9-3bc2bfab92b1"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7e164e99-c282-486b-b9f7-9f9fdc73e7ad"));

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                table: "Project_Employees",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Project_Employees",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Project_Employees",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getutcdate()");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Project_Employees");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Project_Employees");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                table: "Project_Employees",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0a9b0720-8187-4c8d-a7c5-e4417859db36"), "HR" },
                    { new Guid("29995d04-aeeb-44a6-953f-bc5a8f320aec"), "Accountant" },
                    { new Guid("63b33e78-af61-47bc-a1d9-3bc2bfab92b1"), "Software Development " },
                    { new Guid("7e164e99-c282-486b-b9f7-9f9fdc73e7ad"), "Finance" }
                });
        }
    }
}
