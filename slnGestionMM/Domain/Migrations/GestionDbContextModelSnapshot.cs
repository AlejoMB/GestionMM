﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(GestionDbContext))]
    partial class GestionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Authorization.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrador"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Authorization.RolesUser", b =>
                {
                    b.Property<int>("RolesUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolesUserId"));

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RolesUserId");

                    b.HasIndex("RolId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RolesUser");

                    b.HasData(
                        new
                        {
                            RolesUserId = 1,
                            RolId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Authorization.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "System",
                            LastName = "",
                            Password = "System",
                            Username = "System",
                            isActive = false
                        });
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Bodega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bodegas");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colores");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Diseno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disenos");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BodegaId")
                        .HasColumnType("int");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<int?>("DisenoId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int?>("SegmentoId")
                        .HasColumnType("int");

                    b.Property<int?>("TamanoId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoMediaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BodegaId");

                    b.HasIndex("ColorId");

                    b.HasIndex("DisenoId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ProveedorId");

                    b.HasIndex("SegmentoId");

                    b.HasIndex("TamanoId");

                    b.HasIndex("TipoMediaId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Segmento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Segmentos");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Tamano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tamanos");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.TipoMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoMedias");
                });

            modelBuilder.Entity("Domain.Entities.Authorization.RolesUser", b =>
                {
                    b.HasOne("Domain.Entities.Authorization.Rol", "Rol")
                        .WithOne("RolesUser")
                        .HasForeignKey("Domain.Entities.Authorization.RolesUser", "RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Authorization.User", "User")
                        .WithOne("RolesUser")
                        .HasForeignKey("Domain.Entities.Authorization.RolesUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Media", b =>
                {
                    b.HasOne("Domain.Entities.Inventario.Bodega", "Bodega")
                        .WithMany("Medias")
                        .HasForeignKey("BodegaId");

                    b.HasOne("Domain.Entities.Inventario.Color", "Color")
                        .WithMany("Medias")
                        .HasForeignKey("ColorId");

                    b.HasOne("Domain.Entities.Inventario.Diseno", "Diseno")
                        .WithMany("Medias")
                        .HasForeignKey("DisenoId");

                    b.HasOne("Domain.Entities.Inventario.Marca", "Marca")
                        .WithMany("Medias")
                        .HasForeignKey("MarcaId");

                    b.HasOne("Domain.Entities.Inventario.Proveedor", "Proveedor")
                        .WithMany("Medias")
                        .HasForeignKey("ProveedorId");

                    b.HasOne("Domain.Entities.Inventario.Segmento", "Segmento")
                        .WithMany("Medias")
                        .HasForeignKey("SegmentoId");

                    b.HasOne("Domain.Entities.Inventario.Tamano", "Tamano")
                        .WithMany("Medias")
                        .HasForeignKey("TamanoId");

                    b.HasOne("Domain.Entities.Inventario.TipoMedia", "TipoMedia")
                        .WithMany("Medias")
                        .HasForeignKey("TipoMediaId");

                    b.Navigation("Bodega");

                    b.Navigation("Color");

                    b.Navigation("Diseno");

                    b.Navigation("Marca");

                    b.Navigation("Proveedor");

                    b.Navigation("Segmento");

                    b.Navigation("Tamano");

                    b.Navigation("TipoMedia");
                });

            modelBuilder.Entity("Domain.Entities.Authorization.Rol", b =>
                {
                    b.Navigation("RolesUser");
                });

            modelBuilder.Entity("Domain.Entities.Authorization.User", b =>
                {
                    b.Navigation("RolesUser");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Bodega", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Color", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Diseno", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Marca", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Proveedor", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Segmento", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.Tamano", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("Domain.Entities.Inventario.TipoMedia", b =>
                {
                    b.Navigation("Medias");
                });
#pragma warning restore 612, 618
        }
    }
}
