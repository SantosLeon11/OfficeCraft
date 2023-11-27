using OfficeCraft.Models.Entities;

namespace OfficeCraft.Services.IService
{
    public interface IPedidoServices
    {
        public Task<List<Pedido>> GetPedido();
        public Task<Pedido> GetByIdPedido(int id);

        public Task<Pedido> CrearPedido(Pedido i);
        public Task<Pedido> EditarPedido(Pedido i);
        public bool EliminarPedido(int id);
    }
}
