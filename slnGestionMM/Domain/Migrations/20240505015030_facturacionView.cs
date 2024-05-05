using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class facturacionView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturaEnc_TipoEnvios_TipoEnvioId",
                table: "FacturaEnc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoEnvios",
                table: "TipoEnvios");

            migrationBuilder.RenameTable(
                name: "TipoEnvios",
                newName: "TipoEnvio");

            migrationBuilder.RenameColumn(
                name: "cedula",
                table: "Cliente",
                newName: "Cedula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoEnvio",
                table: "TipoEnvio",
                column: "Id");

            migrationBuilder.InsertData(
                table: "MedioPago",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Transferencia" },
                    { 3, "Transportadora" }
                });

            migrationBuilder.InsertData(
                table: "TipoEnvio",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Domicilio" },
                    { 2, "Contra Entrega" }
                });

            migrationBuilder.InsertData(
                table: "Transportadora",
                columns: new[] { "Id", "CostoEnvio", "Name", "ProcentajeVenta" },
                values: new object[] { 1, 0, "Inter Rapidisimo", 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaEnc_TipoEnvio_TipoEnvioId",
                table: "FacturaEnc",
                column: "TipoEnvioId",
                principalTable: "TipoEnvio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturaEnc_TipoEnvio_TipoEnvioId",
                table: "FacturaEnc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoEnvio",
                table: "TipoEnvio");

            migrationBuilder.DeleteData(
                table: "MedioPago",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedioPago",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedioPago",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoEnvio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoEnvio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transportadora",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "TipoEnvio",
                newName: "TipoEnvios");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "Cliente",
                newName: "cedula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoEnvios",
                table: "TipoEnvios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaEnc_TipoEnvios_TipoEnvioId",
                table: "FacturaEnc",
                column: "TipoEnvioId",
                principalTable: "TipoEnvios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
