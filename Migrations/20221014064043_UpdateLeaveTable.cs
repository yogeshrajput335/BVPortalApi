using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVPortalApi.Migrations
{
    public partial class UpdateLeaveTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Leave");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Leave");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Leave",
                newName: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_EmployeeId",
                table: "Leave",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_LeaveTypeId",
                table: "Leave",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leave_Employee_EmployeeId",
                table: "Leave",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leave_LeaveType_LeaveTypeId",
                table: "Leave",
                column: "LeaveTypeId",
                principalTable: "LeaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leave_Employee_EmployeeId",
                table: "Leave");

            migrationBuilder.DropForeignKey(
                name: "FK_Leave_LeaveType_LeaveTypeId",
                table: "Leave");

            migrationBuilder.DropIndex(
                name: "IX_Leave_EmployeeId",
                table: "Leave");

            migrationBuilder.DropIndex(
                name: "IX_Leave_LeaveTypeId",
                table: "Leave");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Leave",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Leave",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Leave",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
