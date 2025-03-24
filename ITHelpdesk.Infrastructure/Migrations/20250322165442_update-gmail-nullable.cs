using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHelpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updategmailnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5839), new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5834), new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5845), new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5844), new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5846) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DateOfBirth", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5851), new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5850), new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5852) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(118), new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(112), new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(119) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(126), new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(124), new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(126) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DateOfBirth", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(132), new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(131), new DateTime(2025, 3, 21, 10, 8, 27, 196, DateTimeKind.Utc).AddTicks(133) });
        }
    }
}
