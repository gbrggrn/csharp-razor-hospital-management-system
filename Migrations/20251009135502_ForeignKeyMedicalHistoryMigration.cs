using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp3_A1.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyMedicalHistoryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "MedicalHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_StaffId",
                table: "MedicalHistories",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Staff_StaffId",
                table: "MedicalHistories",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Staff_StaffId",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_StaffId",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "MedicalHistories");
        }
    }
}
