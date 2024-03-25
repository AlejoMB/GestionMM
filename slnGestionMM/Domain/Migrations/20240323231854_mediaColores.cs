using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class mediaColores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Colores_ColorId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_ColorId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "RgbColor",
                table: "Colores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MediaColores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaColores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaColores_Colores_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaColores_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Colores",
                columns: new[] { "Id", "Name", "RgbColor" },
                values: new object[,]
                {
                    { 1, "Blanco", "#ffffff" },
                    { 2, "Negro", "#ffffff" },
                    { 3, "Rojo", "#ffffff" },
                    { 4, "Beige/Negro", "#ffffff" }
                });

            migrationBuilder.InsertData(
                table: "Disenos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Estampado" },
                    { 2, "Jaspeado - Chispas" },
                    { 3, "Jaspeado - Cuadros" },
                    { 4, "Anti Resvalante" },
                    { 5, "Patas Pollo" },
                    { 6, "Importadas" },
                    { 7, "Gala - Económicas" },
                    { 8, "Gala - Importadas" },
                    { 9, "Edu. Física - Económicas" },
                    { 10, "Edu. Física - Importadas" }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nike" },
                    { 2, "Adiddas" },
                    { 3, "Puma" },
                    { 4, "XPN" },
                    { 5, "Jogo" },
                    { 6, "Jordan" },
                    { 7, "alo" }
                });

            migrationBuilder.InsertData(
                table: "Segmentos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adultos" },
                    { 2, "Niños" }
                });

            migrationBuilder.InsertData(
                table: "Tamanos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Larga" },
                    { 2, "Tobillera" },
                    { 3, "Canilleras" },
                    { 4, "Tobilleras largas (2/4)" },
                    { 5, "Talonera" },
                    { 6, "3/4" },
                    { 7, "Pantalon" },
                    { 8, "Pernera" },
                    { 9, "6-8" },
                    { 10, "4-6" },
                    { 11, "8-10" },
                    { 12, "9-11" }
                });

            migrationBuilder.InsertData(
                table: "TipoMedias",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Deportivas" },
                    { 2, "Calcetines" },
                    { 3, "Mallas" },
                    { 4, "Bucaneras" },
                    { 5, "Calentadora" },
                    { 6, "Compresoras" },
                    { 7, "Dercoradas" },
                    { 8, "Colegialas" },
                    { 9, "Antideslizante" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaColores_ColorId",
                table: "MediaColores",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaColores_MediaId",
                table: "MediaColores",
                column: "MediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaColores");

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Disenos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Segmentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Segmentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tamanos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TipoMedias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoMedias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoMedias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoMedias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoMedias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TipoMedias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TipoMedias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TipoMedias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TipoMedias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "RgbColor",
                table: "Colores");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ColorId",
                table: "Medias",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Colores_ColorId",
                table: "Medias",
                column: "ColorId",
                principalTable: "Colores",
                principalColumn: "Id");
        }
    }
}
