using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class rolesUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "RolesUser",
                columns: table => new
                {
                    RolesUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUser", x => x.RolesUserId);
                    table.ForeignKey(
                        name: "FK_RolesUser_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RolesUser",
                columns: new[] { "RolesUserId", "RolId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RolesUser_RolId",
                table: "RolesUser",
                column: "RolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolesUser_UserId",
                table: "RolesUser",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesUser");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RolId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolId",
                table: "Users",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
