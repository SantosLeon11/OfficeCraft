using OfficeCraft.Models.Entities;

namespace OfficeCraft.Services.IService
{
    public interface IClienteServices
    {
        public Task<List<Cliente>> GetCliente();
        public Task<Cliente> GetByIdCliente(int id);

        public Task<Cliente> CrearCliente(Cliente i);
        public Task<Cliente> EditarCliente(Cliente i);
        public bool EliminarCliente(int id);
    }
}
