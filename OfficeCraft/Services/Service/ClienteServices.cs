using Microsoft.EntityFrameworkCore;
using OfficeCraft.Context;
using OfficeCraft.Models.Entities;
using OfficeCraft.Services.IService;

namespace OfficeCraft.Services.Service
{
    public class ClienteServices:IClienteServices
    {
        private readonly ApplicationDbContext _context;

        //Constructor para usar las tablas de base de datos
        public ClienteServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetCliente()
        {
            try
            {

                return await _context.Clientes.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Cliente> GetByIdCliente(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Cliente response = await _context.Clientes.FirstOrDefaultAsync(x => x.PkCliente == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Cliente> CrearCliente(Cliente i)
        {
            try
            {
                Cliente request = new Cliente()
                {
                    Nombre = i.Nombre,
                    Apellido = i.Apellido,
                    Direccion = i.Direccion,
                    Correo = i.Correo,
                };

                var result = await _context.Clientes.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Cliente> EditarCliente(Cliente i)
        {
            try
            {
                Cliente cliente = _context.Clientes.Find(i.PkCliente);

                cliente.Nombre = i.Nombre;
                cliente.Apellido = i.Apellido;
                cliente.Direccion = i.Direccion;
                cliente.Correo = i.Correo;

                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return cliente;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarCliente(int id)
        {
            try
            {
                Cliente cliente = _context.Clientes.Find(id);

                if (cliente != null)
                {
                    var res = _context.Clientes.Remove(cliente);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }
    }
}
