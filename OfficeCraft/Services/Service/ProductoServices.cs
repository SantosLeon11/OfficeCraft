using Microsoft.EntityFrameworkCore;
using OfficeCraft.Context;
using OfficeCraft.Models.Entities;
using OfficeCraft.Services.IService;

namespace OfficeCraft.Services.Service
{
    public class ProductoServices: IProductoServices
    {
        private readonly ApplicationDbContext _context;

        //Constructor para usar las tablas de base de datos
        public ProductoServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetProducto()
        {
            try
            {

                return await _context.Productos.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Producto> GetByIdProducto(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Producto response = await _context.Productos.FirstOrDefaultAsync(x => x.PkProducto == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Producto> CrearProducto(Producto i)
        {
            try
            {
                Producto request = new Producto()
                {
                    Nombre = i.Nombre,
                    Precio = i.Precio,
                    Existencia = i.Existencia,
                };

                var result = await _context.Productos.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Producto> EditarProducto(Producto i)
        {
            try
            {
                Producto producto = _context.Productos.Find(i.PkProducto);

                producto.Nombre = i.Nombre;
                producto.Precio = i.Precio;
                producto.Existencia = i.Existencia;

                _context.Entry(producto).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return producto;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarProducto(int id)
        {
            try
            {
                Producto producto = _context.Productos.Find(id);

                if (producto != null)
                {
                    var res = _context.Productos.Remove(producto);
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
