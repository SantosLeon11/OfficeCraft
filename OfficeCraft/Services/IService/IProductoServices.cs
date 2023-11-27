using OfficeCraft.Models.Entities;

namespace OfficeCraft.Services.IService
{
    public interface IProductoServices
    {
        public Task<List<Producto>> GetProducto();
        public Task<Producto> GetByIdProducto(int id);

        public Task<Producto> CrearProducto(Producto i);
        public Task<Producto> EditarProducto(Producto i);
        public bool EliminarProducto(int id);
    }
}
