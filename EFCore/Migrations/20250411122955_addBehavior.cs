using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2327529e-09eb-473c-8fbc-4ed15bb9c5a7"), "Accountant" },
                    { new Guid("55435a7f-8197-4344-badb-e05daeed81c1"), "Finance" },
                    { new Guid("e844a30c-08cb-426b-b27c-c3bc05e1265d"), "Software Development " },
                    { new Guid("f30330f3-43ab-49c1-9873-5153f14fccb8"), "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2327529e-09eb-473c-8fbc-4ed15bb9c5a7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("55435a7f-8197-4344-badb-e05daeed81c1"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e844a30c-08cb-426b-b27c-c3bc05e1265d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("f30330f3-43ab-49c1-9873-5153f14fccb8"));

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
    }
}
