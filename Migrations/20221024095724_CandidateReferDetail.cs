using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVPortalApi.Migrations
{
    public partial class CandidateReferDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferBy",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ReferBy",
                table: "Candidates",
                column: "ReferBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Employee_ReferBy",
                table: "Candidates",
                column: "ReferBy",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Employee_ReferBy",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_ReferBy",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ReferBy",
                table: "Candidates");
        }
    }
}
