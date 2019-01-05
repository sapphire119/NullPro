using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnprofessionalsApp.Data.Migrations
{
    public partial class Removed_RatingAndPopularity_From_All_Entites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comments");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfRegistration",
                table: "Firms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsBlackListed",
                table: "Firms",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfRegistration",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "IsBlackListed",
                table: "Firms");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Replies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Popularity",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Popularity",
                table: "Firms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Firms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
