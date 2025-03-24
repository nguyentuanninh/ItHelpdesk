using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITHelpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddatasample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "Email", "GithubUsername", "IsActive", "ModifiedDate", "Name", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(118), new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(112), "", "johndoe", true, new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(119), "Nguyen Tuan Ninh", "password", "1234567890", 0, "ninh" },
                    { 2, new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(126), new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(124), "", "johndoe", true, new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(126), "Nguyen Duy Phuc", "password", "1234567890", 1, "phuc" },
                    { 3, new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(132), new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(131), "", "johndoe", true, new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(133), "Nguyen Dinh Manh", "password", "1234567890", 2, "manh" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
