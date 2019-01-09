using Microsoft.EntityFrameworkCore.Migrations;

namespace UnprofessionalsApp.Data.Migrations
{
    public partial class Removed_IsBlackisted_Property_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlackListed",
                table: "Firms");

            migrationBuilder.RenameColumn(
                name: "IsBlackListed",
                table: "AspNetUsers",
                newName: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AspNetUsers",
                newName: "IsBlackListed");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlackListed",
                table: "Firms",
                nullable: false,
                defaultValue: false);
        }
    }
}
