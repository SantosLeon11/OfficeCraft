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
        }
    }
}
