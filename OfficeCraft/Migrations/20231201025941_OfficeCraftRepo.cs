using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OfficeCraft.Migrations
{
    /// <inheritdoc />
    public partial class OfficeCraftRepo : Migration
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
                    Existencia = table.Column<int>(type: "int", nullable: false),
                    UrlImagenPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    FkCliente = table.Column<int>(type: "int", nullable: true),
                    FkProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PkPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "PkCliente");
                    table.ForeignKey(
                        name: "FK_Pedidos_Productos_FkProducto",
                        column: x => x.FkProducto,
                        principalTable: "Productos",
                        principalColumn: "PkProducto");
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
                table: "Clientes",
                columns: new[] { "PkCliente", "Apellido", "Correo", "Nombre" },
                values: new object[,]
                {
                    { 1, "Sosa", "majo@gmail.com", "Maria" },
                    { 2, "Madrazo", "gino@gmail.com", "Gino" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "PkProducto", "Existencia", "Nombre", "Precio", "UrlImagenPath" },
                values: new object[,]
                {
                    { 1, 100, "Calculadora Casio Azul", 1150, "" },
                    { 2, 100, "Calculadora Casio Rosa", 1150, "" },
                    { 3, 100, "Mochila Chenson Negra", 250, "img/productos/3" },
                    { 4, 100, "Mochila Chenson Pastel", 250, "img/productos/4" },
                    { 5, 100, "Colores Norma 50pz", 450, "img/productos/5" },
                    { 6, 100, "Colores Norma 36pz", 250, "img/productos/6" },
                    { 7, 100, "Libreta Norma Cuadros Grandes Ferrari", 90, "img/productos/7" },
                    { 8, 100, "Libreta Kiut Cuadros Grandes Pink", 90, "img/productos/8" },
                    { 9, 100, "Kit de Geometria Color Morado", 50, "img/productos/9" },
                    { 10, 100, "Kit de Geometria Color Azul", 50, "img/productos/10" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRoles", "Nombre" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "empleado" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PKUsuario", "Apellido", "Contraseña", "FkRol", "Nombre", "NombreUsuario" },
                values: new object[,]
                {
                    { 1, "Santos", "1234", 1, "Jorge", "joge" },
                    { 2, "Peña", "1234", 2, "David", "davi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FkCliente",
                table: "Pedidos",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FkProducto",
                table: "Pedidos",
                column: "FkProducto");

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
