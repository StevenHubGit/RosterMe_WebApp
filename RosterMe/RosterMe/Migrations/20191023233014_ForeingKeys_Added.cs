using Microsoft.EntityFrameworkCore.Migrations;

namespace RosterMe.Migrations
{
    public partial class ForeingKeys_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Employees_EmployeeId",
                table: "Availability");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Availability");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Availability",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Login_EmployeeId",
                table: "Login",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Employees_EmployeeId",
                table: "Availability",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Employees_EmployeeId",
                table: "Login",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Employees_EmployeeId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Login_Employees_EmployeeId",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_EmployeeId",
                table: "Login");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Availability",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Availability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Employees_EmployeeId",
                table: "Availability",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
