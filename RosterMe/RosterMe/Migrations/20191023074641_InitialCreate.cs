using Microsoft.EntityFrameworkCore.Migrations;

namespace RosterMe.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Employees_EmployeeId",
                table: "Timesheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Shift_ShiftId",
                table: "Timesheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timesheets",
                table: "Timesheets");

            migrationBuilder.RenameTable(
                name: "Timesheets",
                newName: "Timesheet");

            migrationBuilder.RenameIndex(
                name: "IX_Timesheets_ShiftId",
                table: "Timesheet",
                newName: "IX_Timesheet_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Timesheets_EmployeeId",
                table: "Timesheet",
                newName: "IX_Timesheet_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timesheet",
                table: "Timesheet",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheet_Employees_EmployeeId",
                table: "Timesheet",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheet_Shift_ShiftId",
                table: "Timesheet",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timesheet_Employees_EmployeeId",
                table: "Timesheet");

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheet_Shift_ShiftId",
                table: "Timesheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timesheet",
                table: "Timesheet");

            migrationBuilder.RenameTable(
                name: "Timesheet",
                newName: "Timesheets");

            migrationBuilder.RenameIndex(
                name: "IX_Timesheet_ShiftId",
                table: "Timesheets",
                newName: "IX_Timesheets_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Timesheet_EmployeeId",
                table: "Timesheets",
                newName: "IX_Timesheets_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timesheets",
                table: "Timesheets",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Employees_EmployeeId",
                table: "Timesheets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Shift_ShiftId",
                table: "Timesheets",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
