using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    LevelID = table.Column<int>(nullable: false),
                    TypeAt = table.Column<int>(nullable: false),
                    Named = table.Column<string>(maxLength: 30, nullable: false),
                    Command = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoleAuthorizes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    RoleInformationID = table.Column<int>(nullable: true),
                    PermissionInformationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAuthorizes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleAuthorizes_Permissions_PermissionInformationID",
                        column: x => x.PermissionInformationID,
                        principalTable: "Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleAuthorizes_Roles_RoleInformationID",
                        column: x => x.RoleInformationID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAuthorizes_PermissionInformationID",
                table: "RoleAuthorizes",
                column: "PermissionInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAuthorizes_RoleInformationID",
                table: "RoleAuthorizes",
                column: "RoleInformationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAuthorizes");

            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
