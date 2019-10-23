using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RosterMe.Migrations
{
    public partial class Login_LoginTrails_Availability_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginTrail_Login_LoginId",
                table: "LoginTrail");

            migrationBuilder.RenameColumn(
                name: "LoginId",
                table: "LoginTrail",
                newName: "LogInId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginTrail_LoginId",
                table: "LoginTrail",
                newName: "IX_LoginTrail_LogInId");

            migrationBuilder.AlterColumn<int>(
                name: "LogInId",
                table: "LoginTrail",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    AvailabilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    AvailableDate = table.Column<DateTime>(nullable: false),
                    AvailableFromTime = table.Column<DateTime>(nullable: false),
                    AvailableToTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.AvailabilityId);
                    table.ForeignKey(
                        name: "FK_Availability_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availability_EmployeeId",
                table: "Availability",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginTrail_Login_LogInId",
                table: "LoginTrail",
                column: "LogInId",
                principalTable: "Login",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginTrail_Login_LogInId",
                table: "LoginTrail");

            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.RenameColumn(
                name: "LogInId",
                table: "LoginTrail",
                newName: "LoginId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginTrail_LogInId",
                table: "LoginTrail",
                newName: "IX_LoginTrail_LoginId");

            migrationBuilder.AlterColumn<int>(
                name: "LoginId",
                table: "LoginTrail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LoginTrail_Login_LoginId",
                table: "LoginTrail",
                column: "LoginId",
                principalTable: "Login",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
