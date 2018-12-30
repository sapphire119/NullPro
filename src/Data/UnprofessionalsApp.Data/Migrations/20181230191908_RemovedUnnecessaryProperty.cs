using Microsoft.EntityFrameworkCore.Migrations;

namespace UnprofessionalsApp.Data.Migrations
{
    public partial class RemovedUnnecessaryProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlToTradersRegistry",
                table: "Firms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlToTradersRegistry",
                table: "Firms",
                nullable: false,
                defaultValue: "");
        }
    }
}
