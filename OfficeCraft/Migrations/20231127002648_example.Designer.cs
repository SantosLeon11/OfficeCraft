﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfficeCraft.Context;

#nullable disable

namespace OfficeCraft.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231127002648_example")]
    partial class example
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OfficeCraft.Models.Entities.Cliente", b =>
                {
                    b.Property<int>("PkCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkCliente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("OfficeCraft.Models.Entities.Pedido", b =>
                {
                    b.Property<int>("PkPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkPedido"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ClientesPkCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FkCliente")
                        .HasColumnType("int");

                    b.Property<int?>("FkProducto")
                        .HasColumnType("int");

                    b.Property<int>("ProductosPkProducto")
                        .HasColumnType("int");

                    b.HasKey("PkPedido");

                    b.HasIndex("ClientesPkCliente");

                    b.HasIndex("ProductosPkProducto");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("OfficeCraft.Models.Entities.Producto", b =>
                {
                    b.Property<int>("PkProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkProducto"));

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("PkProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("OfficeCraft.Models.Entities.Rol", b =>
                {
                    b.Property<int>("PkRoles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRoles"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRoles");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            PkRoles = 1,
                            Nombre = "admin"
                        },
                        new
                        {
                            PkRoles = 2,
                            Nombre = "sa"
                        });
                });

            modelBuilder.Entity("OfficeCraft.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("PKUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PKUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            PKUsuario = 1,
                            Apellido = "Sosa",
                            Contraseña = "1234",
                            FkRol = 1,
                            Nombre = "Maria Jose",
                            NombreUsuario = "Majo"
                        });
                });

            modelBuilder.Entity("OfficeCraft.Models.Entities.Pedido", b =>
                {
                    b.HasOne("OfficeCraft.Models.Entities.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClientesPkCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OfficeCraft.Models.Entities.Producto", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductosPkProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("OfficeCraft.Models.Entities.Usuario", b =>
                {
                    b.HasOne("OfficeCraft.Models.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
