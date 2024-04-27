using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class proveedor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprasEnc_MedioPagoCompras_MedioPagoId",
                table: "ComprasEnc");

            migrationBuilder.DropTable(
                name: "MedioPagoCompras");

            migrationBuilder.CreateTable(
                name: "MedioPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedioPago", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasEnc_MedioPago_MedioPagoId",
                table: "ComprasEnc",
                column: "MedioPagoId",
                principalTable: "MedioPago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprasEnc_MedioPago_MedioPagoId",
                table: "ComprasEnc");

            migrationBuilder.DropTable(
                name: "MedioPago");

            migrationBuilder.CreateTable(
                name: "MedioPagoCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedioPagoCompras", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasEnc_MedioPagoCompras_MedioPagoId",
                table: "ComprasEnc",
                column: "MedioPagoId",
                principalTable: "MedioPagoCompras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
