using Microsoft.EntityFrameworkCore;
using OfficeCraft.Models.Entities;
using System.Collections.Generic;

namespace OfficeCraft.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insert en la tabla Rol

            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRoles = 1,
                    Nombre = "admin"
                },
                new Rol
                {
                    PkRoles = 2,
                    Nombre = "empleado"
                }
            );

            //Insert en la tabla usuario

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PKUsuario = 1,
                    Nombre = "Jorge",
                    Apellido = "Santos",
                    NombreUsuario = "joge",
                    Contraseña = "1234",
                    FkRol = 1
                },
                new Usuario
                {
                    PKUsuario = 2,
                    Nombre = "David",
                    Apellido = "Peña",
                    NombreUsuario = "davi",
                    Contraseña = "1234",
                    FkRol = 2
                }
            );
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    PkCliente = 1,
                    Nombre = "Maria",
                    Apellido = "Sosa",
                    Correo = "majo@gmail.com"
                },
                new Cliente
                {
                    PkCliente = 2,
                    Nombre = "Gino",
                    Apellido = "Madrazo",
                    Correo = "gino@gmail.com"
                }
            );
            /*modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    PkProducto = 1,
                    Nombre = "Calculadora Casio Azul",
                    Precio = 1150,
                    Existencia = 100,
                    UrlImagenPath = ""
                },
                new Producto
                {
                    PkProducto = 2,
                    Nombre = "Calculadora Casio Rosa",
                    Precio = 1150,
                    Existencia = 100,
                    UrlImagenPath = ""
                },
                new Producto
                {
                    PkProducto = 3,
                    Nombre = "Mochila Chenson Negra",
                    Precio = 250,
                    Existencia = 100,
                    UrlImagenPath = "img/productos/3"
                },
                new Producto
                {
                    PkProducto = 4,
                    Nombre = "Mochila Chenson Pastel",
                    Precio = 250,
                    Existencia = 100,
                    UrlImagenPath = "img/productos/4"
                },
                new Producto
                {
                    PkProducto = 5,
                    Nombre = "Colores Norma 50pz",
                    Precio = 450,
                    Existencia = 100,
                    UrlImagenPath = "img/productos/5"
                },
                new Producto
                {
                    PkProducto = 6,
                    Nombre = "Colores Norma 36pz",
                    Precio = 250,
                    Existencia = 100,
                    UrlImagenPath = "img/productos/6"
                },
                new Producto
                {
                    PkProducto = 7,
                    Nombre = "Libreta Norma Cuadros Grandes Ferrari",
                    Precio = 90,
                    Existencia = 100,
                    UrlImagenPath = "img/productos/7"
                },
                new Producto
                {
                    PkProducto = 8,
                    Nombre = "Libreta Kiut Cuadros Grandes Pink",
                    Precio = 90,
                    Existencia = 100,
                    UrlImagenPath = "img/productos/8"
                },

                new Producto
                {
                    PkProducto = 9,
                    Nombre = "Kit de Geometria Color Morado",
                    Precio = 50,
                    Existencia = 100,
                    UrlImagenPath = "img/productos/9"
                },
                new Producto
                {
                    PkProducto = 10,
                    Nombre = "Kit de Geometria Color Azul",
                    Precio = 50,
                    Existencia = 100,
                    UrlImagenPath = "img/productos/10"
                }
            );*/
        }
    }
}
