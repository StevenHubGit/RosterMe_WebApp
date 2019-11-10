using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RosterMe.Migrations
{
    public partial class ColumnInShiftInvitation_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShftCreatedDate",
                table: "Shift");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShiftCreatedDate",
                table: "Shift",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftCreatedDate",
                table: "Shift");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShftCreatedDate",
                table: "Shift",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
