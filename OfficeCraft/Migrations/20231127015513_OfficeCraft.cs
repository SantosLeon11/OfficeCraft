﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OfficeCraft.Migrations
{
    /// <inheritdoc />
    public partial class OfficeCraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    PkCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.PkCliente);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    PkProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.PkProducto);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRoles = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRoles);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PkPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkCliente = table.Column<int>(type: "int", nullable: false),
                    ClientesPkCliente = table.Column<int>(type: "int", nullable: false),
                    FkProducto = table.Column<int>(type: "int", nullable: false),
                    ProductosPkProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PkPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClientesPkCliente",
                        column: x => x.ClientesPkCliente,
                        principalTable: "Clientes",
                        principalColumn: "PkCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Productos_ProductosPkProducto",
                        column: x => x.ProductosPkProducto,
                        principalTable: "Productos",
                        principalColumn: "PkProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PKUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PKUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRoles");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRoles", "Nombre" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "sa" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PKUsuario", "Apellido", "Contraseña", "FkRol", "Nombre", "NombreUsuario" },
                values: new object[] { 1, "Sosa", "1234", 1, "Maria Jose", "Majo" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClientesPkCliente",
                table: "Pedidos",
                column: "ClientesPkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProductosPkProducto",
                table: "Pedidos",
                column: "ProductosPkProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkRol",
                table: "Usuarios",
                column: "FkRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
