using OfficeCraft.Models.Entities;

namespace OfficeCraft.Services.IService
{
    public interface IOfertaServices
    {
        public Task<List<Oferta>> GetOferta();
        public Task<Oferta> GetByIdOferta(int id);

        public Task<Oferta> CrearOferta(Oferta i);
        public Task<Oferta> EditarOferta(Oferta i);
        public bool EliminarOferta(int id);
    }
}
