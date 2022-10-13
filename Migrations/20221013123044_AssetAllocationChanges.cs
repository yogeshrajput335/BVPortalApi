using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVPortalApi.Migrations
{
    public partial class AssetAllocationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_AllocatedById",
                table: "AssetAllocation",
                column: "AllocatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_AllocatedToId",
                table: "AssetAllocation",
                column: "AllocatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_AssetId",
                table: "AssetAllocation",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_Assets_AssetId",
                table: "AssetAllocation",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_Employee_AllocatedById",
                table: "AssetAllocation",
                column: "AllocatedById",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_Employee_AllocatedToId",
                table: "AssetAllocation",
                column: "AllocatedToId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocation_Assets_AssetId",
                table: "AssetAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocation_Employee_AllocatedById",
                table: "AssetAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocation_Employee_AllocatedToId",
                table: "AssetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_AssetAllocation_AllocatedById",
                table: "AssetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_AssetAllocation_AllocatedToId",
                table: "AssetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_AssetAllocation_AssetId",
                table: "AssetAllocation");
        }
    }
}
