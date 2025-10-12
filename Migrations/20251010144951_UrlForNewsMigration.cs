using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp3_A1.Migrations
{
    /// <inheritdoc />
    public partial class UrlForNewsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "NewsItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "NewsItems");
        }
    }
}
