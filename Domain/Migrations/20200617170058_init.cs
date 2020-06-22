using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BM_Menu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Parent = table.Column<int>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    HtmlClass = table.Column<string>(nullable: true),
                    IsShow = table.Column<bool>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    CreateTime = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<string>(nullable: true),
                    Creator = table.Column<int>(nullable: false),
                    Mender = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BM_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BM_Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    CreateTime = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<string>(nullable: true),
                    Creator = table.Column<int>(nullable: false),
                    Mender = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BM_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BM_RoleMenu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(nullable: false),
                    MenuId = table.Column<long>(nullable: false),
                    CreateTime = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<string>(nullable: true),
                    Creator = table.Column<int>(nullable: false),
                    Mender = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BM_RoleMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BM_User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BM_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BM_UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(nullable: false),
                    MenuId = table.Column<long>(nullable: false),
                    CreateTime = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<string>(nullable: true),
                    Creator = table.Column<int>(nullable: false),
                    Mender = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BM_UserRole", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BM_Menu");

            migrationBuilder.DropTable(
                name: "BM_Role");

            migrationBuilder.DropTable(
                name: "BM_RoleMenu");

            migrationBuilder.DropTable(
                name: "BM_User");

            migrationBuilder.DropTable(
                name: "BM_UserRole");
        }
    }
}
