using Microsoft.EntityFrameworkCore;
using OfficeCraft.Context;
using OfficeCraft.Models.Entities;
using OfficeCraft.Services.IService;

namespace OfficeCraft.Services.Service
{
    public class PedidoServices: IPedidoServices
    {
        private readonly ApplicationDbContext _context;

        //Constructor para usar las tablas de base de datos
        public PedidoServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pedido>> GetPedido()
        {
            try
            {
                //int contador = 0;
                //for (int i = 0; i < 50; i++)
                //{
                //    contador++; // Incrementa el contador de uno en uno
                //    _context.Database.ExecuteSqlInterpolated($"EXEC sp_DescontarExistencia {contador}");
                //}
                return await _context.Pedidos.Include(y => y.Clientes).Include(y => y.Productos).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Pedido> GetByIdPedido(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Pedido response = await _context.Pedidos.FirstOrDefaultAsync(x => x.PkPedido == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Pedido> CrearPedido(Pedido i)
        {
            try
            {
                Pedido request = new Pedido()
                {
                    Cantidad = i.Cantidad,
                    FechaPedido = i.FechaPedido,
                    FkCliente = i.FkCliente,
                    FkProducto = i.FkProducto,
                };

                var result = await _context.Pedidos.AddAsync(request);
                await _context.SaveChangesAsync();

                // Actualizar la existencia del producto
                await ActualizarExistenciaProducto(request.FkProducto.Value, request.Cantidad);


                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Pedido> EditarPedido(Pedido i)
        {
            try
            {
                Pedido pedido = _context.Pedidos.Find(i.PkPedido);

                pedido.Cantidad = i.Cantidad;
                pedido.FechaPedido = i.FechaPedido;
                pedido.FkCliente = i.FkCliente;
                pedido.FkProducto = i.FkProducto;

                _context.Entry(pedido).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return pedido;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public async Task ActualizarExistenciaProducto(int productoId, int cantidad)
        {
            try
            {
                var producto = await _context.Productos.FindAsync(productoId);
                if (producto != null)
                {
                    producto.Existencia -= cantidad;
                    _context.Entry(producto).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error al actualizar la existencia del producto: " + ex.Message);
            }
        }
        public bool EliminarPedido(int id)
        {
            try
            {
                Pedido pedido = _context.Pedidos.Find(id);

                if (pedido != null)
                {
                    var res = _context.Pedidos.Remove(pedido);
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
