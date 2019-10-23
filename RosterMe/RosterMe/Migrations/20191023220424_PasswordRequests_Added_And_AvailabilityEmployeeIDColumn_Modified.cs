using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RosterMe.Migrations
{
    public partial class PasswordRequests_Added_And_AvailabilityEmployeeIDColumn_Modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Employees_EmployeeId",
                table: "Availability");

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

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Availability",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Availability",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timesheet",
                table: "Timesheet",
                column: "AttendanceId");

            migrationBuilder.CreateTable(
                name: "PasswordRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<int>(nullable: false),
                    NewPassword = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordRequest", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_PasswordRequest_Login_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Login",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordRequest_LoginId",
                table: "PasswordRequest",
                column: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Employees_EmployeeId",
                table: "Availability",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Availability_Employees_EmployeeId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheet_Employees_EmployeeId",
                table: "Timesheet");

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheet_Shift_ShiftId",
                table: "Timesheet");

            migrationBuilder.DropTable(
                name: "PasswordRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timesheet",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Availability");

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

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Availability",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timesheets",
                table: "Timesheets",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Employees_EmployeeId",
                table: "Availability",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

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
