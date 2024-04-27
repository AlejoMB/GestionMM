using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class proveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Proveedores_ProveedorId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_ProveedorId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Proveedores",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Proveedores",
                newName: "Celular");

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

            migrationBuilder.CreateTable(
                name: "ComprasEnc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    MedioPagoId = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pagado = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreadoPorUser = table.Column<int>(type: "int", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasEnc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprasEnc_MedioPagoCompras_MedioPagoId",
                        column: x => x.MedioPagoId,
                        principalTable: "MedioPagoCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprasEnc_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComprasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncabezadoId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    CostoUnitario = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprasDetalle_ComprasEnc_EncabezadoId",
                        column: x => x.EncabezadoId,
                        principalTable: "ComprasEnc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprasDetalle_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 2,
                column: "RgbColor",
                value: "#000000");

            migrationBuilder.UpdateData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 3,
                column: "RgbColor",
                value: "#FF0000");

            migrationBuilder.UpdateData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "RgbColor" },
                values: new object[] { "Beige", "#F3E5AB" });

            migrationBuilder.InsertData(
                table: "Colores",
                columns: new[] { "Id", "Name", "RgbColor" },
                values: new object[,]
                {
                    { 5, "Fucsia", "#E68FAC" },
                    { 6, "Azul", "#0000ff" },
                    { 7, "Amarillo", "#FFFF00" },
                    { 8, "Verde", "#008000" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalle_EncabezadoId",
                table: "ComprasDetalle",
                column: "EncabezadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalle_MediaId",
                table: "ComprasDetalle",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasEnc_MedioPagoId",
                table: "ComprasEnc",
                column: "MedioPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasEnc_ProveedorId",
                table: "ComprasEnc",
                column: "ProveedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprasDetalle");

            migrationBuilder.DropTable(
                name: "ComprasEnc");

            migrationBuilder.DropTable(
                name: "MedioPagoCompras");

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Proveedores",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Proveedores",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 2,
                column: "RgbColor",
                value: "#ffffff");

            migrationBuilder.UpdateData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 3,
                column: "RgbColor",
                value: "#ffffff");

            migrationBuilder.UpdateData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "RgbColor" },
                values: new object[] { "Beige/Negro", "#ffffff" });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ProveedorId",
                table: "Medias",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Proveedores_ProveedorId",
                table: "Medias",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id");
        }
    }
}
