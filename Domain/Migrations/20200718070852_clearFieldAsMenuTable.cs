using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class clearFieldAsMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlClass",
                table: "BM_Menu");

            migrationBuilder.DropColumn(
                name: "IsButton",
                table: "BM_Menu");

            migrationBuilder.DropColumn(
                name: "IsHide",
                table: "BM_Menu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HtmlClass",
                table: "BM_Menu",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsButton",
                table: "BM_Menu",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHide",
                table: "BM_Menu",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
