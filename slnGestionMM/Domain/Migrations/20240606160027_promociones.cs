using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class promociones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaEnPromocion",
                table: "Medias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "FacturaEnc",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "595a20c1-bd9d-4df2-920a-0d8e0c0677a7", "AQAAAAIAAYagAAAAEArkJGXSi6Vj6caS0U7BnHMI+zsKQNKnvxKx/eBl1wbkv7E1ajuoc/LdQk18zATDiw==", "3e08fa80-7769-4ade-80f2-f58cbead741e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaEnPromocion",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "FacturaEnc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "051d33fe-8d04-47cf-b069-644b4425f688", "AQAAAAIAAYagAAAAEMFMpHaIOgts4JXbCpdWFCMaihCeEFHd0kNi1yJ52xzNoL17QvMUoCgfh+MpbWb52w==", "ca771903-e247-437e-96cc-06981f2398a7" });
        }
    }
}
