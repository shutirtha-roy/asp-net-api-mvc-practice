using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstDemo.Web.Data.Migrations
{
    public partial class AddStudentData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Cgpa", "Name" },
                values: new object[] { new Guid("13530e69-aeb3-4a44-b6a0-714546093fe7"), "Dhaka", 3.0, "Samin" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Cgpa", "Name" },
                values: new object[] { new Guid("2fa3a5d2-c1f9-48a8-9ce4-cc05c3b739ae"), "Dhaka", 2.0, "Apurba" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Cgpa", "Name" },
                values: new object[] { new Guid("9fc6abea-0d6d-4168-b147-549f2a64a174"), "Dhaka", 4.0, "Asif" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("13530e69-aeb3-4a44-b6a0-714546093fe7"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("2fa3a5d2-c1f9-48a8-9ce4-cc05c3b739ae"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("9fc6abea-0d6d-4168-b147-549f2a64a174"));
        }
    }
}
