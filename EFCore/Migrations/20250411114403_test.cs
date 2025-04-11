using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Project_Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6752547e-de0d-498f-b60b-c56126680eae"), "Finance" },
                    { new Guid("9bd5bfbc-531a-4712-8b4a-98e413eb315a"), "Accountant" },
                    { new Guid("a9dbb8db-8936-43d5-a312-021cbf63b70a"), "HR" },
                    { new Guid("eb9bda57-9a16-4f5e-bbf7-f09c59321060"), "Software Development " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("6752547e-de0d-498f-b60b-c56126680eae"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9bd5bfbc-531a-4712-8b4a-98e413eb315a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a9dbb8db-8936-43d5-a312-021cbf63b70a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("eb9bda57-9a16-4f5e-bbf7-f09c59321060"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Project_Employees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

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
    }
}
