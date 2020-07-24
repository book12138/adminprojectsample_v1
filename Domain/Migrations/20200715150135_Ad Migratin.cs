using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class AdMigratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "BM_Menu",
                newName: "Url");

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "BM_Menu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "BM_Menu",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsButton",
                table: "BM_Menu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHide",
                table: "BM_Menu",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enable",
                table: "BM_Menu");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "BM_Menu");

            migrationBuilder.DropColumn(
                name: "IsButton",
                table: "BM_Menu");

            migrationBuilder.DropColumn(
                name: "IsHide",
                table: "BM_Menu");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "BM_Menu",
                newName: "url");
        }
    }
}
