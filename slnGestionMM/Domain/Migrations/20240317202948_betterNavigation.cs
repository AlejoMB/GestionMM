using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class betterNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdBodega",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "IdColor",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "IdDiseno",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "IdProveedor",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "IdSegmento",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "IdTamano",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "IdTipoMedia",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "IdBodega",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdColor",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDiseno",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMarca",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProveedor",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSegmento",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTamano",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoMedia",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
