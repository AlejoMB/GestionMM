using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bodegas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodegas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RgbColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disenos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disenos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosFactu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosFactu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segmentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tamanos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamanos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEnvio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEnvio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportadora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoEnvio = table.Column<int>(type: "int", nullable: false),
                    ProcentajeVenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_ComprasEnc_MedioPago_MedioPagoId",
                        column: x => x.MedioPagoId,
                        principalTable: "MedioPago",
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
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodegaId = table.Column<int>(type: "int", nullable: true),
                    TamanoId = table.Column<int>(type: "int", nullable: true),
                    TipoMediaId = table.Column<int>(type: "int", nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: true),
                    DisenoId = table.Column<int>(type: "int", nullable: true),
                    SegmentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_Bodegas_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodegas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medias_Disenos_DisenoId",
                        column: x => x.DisenoId,
                        principalTable: "Disenos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medias_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medias_Segmentos_SegmentoId",
                        column: x => x.SegmentoId,
                        principalTable: "Segmentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medias_Tamanos_TamanoId",
                        column: x => x.TamanoId,
                        principalTable: "Tamanos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medias_TipoMedias_TipoMediaId",
                        column: x => x.TipoMediaId,
                        principalTable: "TipoMedias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FacturaEnc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    EstadoFactuId = table.Column<int>(type: "int", nullable: false),
                    TipoEnvioId = table.Column<int>(type: "int", nullable: false),
                    NoGuia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedioPagoId = table.Column<int>(type: "int", nullable: false),
                    TransportadoraId = table.Column<int>(type: "int", nullable: true),
                    CreadoPorUser = table.Column<int>(type: "int", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaEnc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturaEnc_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaEnc_EstadosFactu_EstadoFactuId",
                        column: x => x.EstadoFactuId,
                        principalTable: "EstadosFactu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaEnc_MedioPago_MedioPagoId",
                        column: x => x.MedioPagoId,
                        principalTable: "MedioPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaEnc_TipoEnvio_TipoEnvioId",
                        column: x => x.TipoEnvioId,
                        principalTable: "TipoEnvio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaEnc_Transportadora_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadora",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "Existencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaRef = table.Column<int>(type: "int", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Existencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Existencias_Medias_MediaRef",
                        column: x => x.MediaRef,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "FacturaDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncabezadoId = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_FacturaEnc_EncabezadoId",
                        column: x => x.EncabezadoId,
                        principalTable: "FacturaEnc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "Administrador", "Administrador" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 0, "186cc4a1-7652-4047-967b-8aa82de3e7ea", "alejo0921@gmail.com", true, false, null, null, "alejo0921@gmail.com", "AQAAAAIAAYagAAAAEKwegSpTPem9PGSTfxFZzvvuYg/XWkdkzJ/ajgP7Jg+sno8esdf/u3WxZ5IJvkHFVA==", null, false, "f34f6cc2-4831-496c-9e23-e217c5b25bdc", false, "alejo0921@gmail.com" });

            migrationBuilder.InsertData(
                table: "Colores",
                columns: new[] { "Id", "Name", "RgbColor" },
                values: new object[,]
                {
                    { 1, "Blanco", "#ffffff" },
                    { 2, "Negro", "#000000" },
                    { 3, "Rojo", "#FF0000" },
                    { 4, "Beige", "#F3E5AB" },
                    { 5, "Fucsia", "#E68FAC" },
                    { 6, "Azul", "#0000ff" },
                    { 7, "Amarillo", "#FFFF00" },
                    { 8, "Verde", "#008000" }
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
                table: "MedioPago",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Transferencia" },
                    { 3, "Transportadora" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Administrador" });

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
                table: "TipoEnvio",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Domicilio" },
                    { 2, "Contra Entrega" }
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

            migrationBuilder.InsertData(
                table: "Transportadora",
                columns: new[] { "Id", "CostoEnvio", "Name", "ProcentajeVenta" },
                values: new object[] { 1, 0, "Inter Rapidisimo", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username", "isActive" },
                values: new object[] { 1, "System", "", "System", "System", false });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });

            migrationBuilder.InsertData(
                table: "RolesUser",
                columns: new[] { "RolesUserId", "RolId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Existencias_MediaRef",
                table: "Existencias",
                column: "MediaRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_EncabezadoId",
                table: "FacturaDetalle",
                column: "EncabezadoId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_MediaId",
                table: "FacturaDetalle",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaEnc_ClienteId",
                table: "FacturaEnc",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaEnc_EstadoFactuId",
                table: "FacturaEnc",
                column: "EstadoFactuId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaEnc_MedioPagoId",
                table: "FacturaEnc",
                column: "MedioPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaEnc_TipoEnvioId",
                table: "FacturaEnc",
                column: "TipoEnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaEnc_TransportadoraId",
                table: "FacturaEnc",
                column: "TransportadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaColores_ColorId",
                table: "MediaColores",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaColores_MediaId",
                table: "MediaColores",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_BodegaId",
                table: "Medias",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_DisenoId",
                table: "Medias",
                column: "DisenoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MarcaId",
                table: "Medias",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_SegmentoId",
                table: "Medias",
                column: "SegmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TamanoId",
                table: "Medias",
                column: "TamanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TipoMediaId",
                table: "Medias",
                column: "TipoMediaId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ComprasDetalle");

            migrationBuilder.DropTable(
                name: "Existencias");

            migrationBuilder.DropTable(
                name: "FacturaDetalle");

            migrationBuilder.DropTable(
                name: "MediaColores");

            migrationBuilder.DropTable(
                name: "RolesUser");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ComprasEnc");

            migrationBuilder.DropTable(
                name: "FacturaEnc");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EstadosFactu");

            migrationBuilder.DropTable(
                name: "MedioPago");

            migrationBuilder.DropTable(
                name: "TipoEnvio");

            migrationBuilder.DropTable(
                name: "Transportadora");

            migrationBuilder.DropTable(
                name: "Bodegas");

            migrationBuilder.DropTable(
                name: "Disenos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Segmentos");

            migrationBuilder.DropTable(
                name: "Tamanos");

            migrationBuilder.DropTable(
                name: "TipoMedias");
        }
    }
}
