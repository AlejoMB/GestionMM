using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Bodegas_BodegaId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Colores_ColorId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Disenos_DisenoId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Marcas_MarcaId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Proveedores_ProveedorId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Segmentos_SegmentoId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Tamanos_TamanoId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_TipoMedias_TipoMediaId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "IdTipoTela",
                table: "Medias",
                newName: "IdTipoMedia");

            migrationBuilder.AlterColumn<int>(
                name: "TipoMediaId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TamanoId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SegmentoId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DisenoId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BodegaId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Bodegas_BodegaId",
                table: "Medias",
                column: "BodegaId",
                principalTable: "Bodegas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Colores_ColorId",
                table: "Medias",
                column: "ColorId",
                principalTable: "Colores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Disenos_DisenoId",
                table: "Medias",
                column: "DisenoId",
                principalTable: "Disenos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Marcas_MarcaId",
                table: "Medias",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Proveedores_ProveedorId",
                table: "Medias",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Segmentos_SegmentoId",
                table: "Medias",
                column: "SegmentoId",
                principalTable: "Segmentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Tamanos_TamanoId",
                table: "Medias",
                column: "TamanoId",
                principalTable: "Tamanos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_TipoMedias_TipoMediaId",
                table: "Medias",
                column: "TipoMediaId",
                principalTable: "TipoMedias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Bodegas_BodegaId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Colores_ColorId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Disenos_DisenoId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Marcas_MarcaId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Proveedores_ProveedorId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Segmentos_SegmentoId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Tamanos_TamanoId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_TipoMedias_TipoMediaId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "IdTipoMedia",
                table: "Medias",
                newName: "IdTipoTela");

            migrationBuilder.AlterColumn<int>(
                name: "TipoMediaId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TamanoId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SegmentoId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DisenoId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BodegaId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Bodegas_BodegaId",
                table: "Medias",
                column: "BodegaId",
                principalTable: "Bodegas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Colores_ColorId",
                table: "Medias",
                column: "ColorId",
                principalTable: "Colores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Disenos_DisenoId",
                table: "Medias",
                column: "DisenoId",
                principalTable: "Disenos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Marcas_MarcaId",
                table: "Medias",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Proveedores_ProveedorId",
                table: "Medias",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Segmentos_SegmentoId",
                table: "Medias",
                column: "SegmentoId",
                principalTable: "Segmentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Tamanos_TamanoId",
                table: "Medias",
                column: "TamanoId",
                principalTable: "Tamanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_TipoMedias_TipoMediaId",
                table: "Medias",
                column: "TipoMediaId",
                principalTable: "TipoMedias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
