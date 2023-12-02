using Microsoft.EntityFrameworkCore;
using OfficeCraft.Context;
using OfficeCraft.Models.Entities;
using OfficeCraft.Services.IService;

namespace OfficeCraft.Services.Service
{
    public class OfertaServices: IOfertaServices
    {
        private readonly ApplicationDbContext _context;

        //Constructor para usar las tablas de base de datos
        public OfertaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Oferta>> GetOferta()
        {
            try
            {

                return await _context.Ofertas.Include(y => y.Productos).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Oferta> GetByIdOferta(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Oferta response = await _context.Ofertas.FirstOrDefaultAsync(x => x.PkOferta == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Oferta> CrearOferta(Oferta i)
        {
            try
            {
                Oferta request = new Oferta()
                {
                    Descuento = i.Descuento,
                    FkProducto = i.FkProducto,
                };

                var result = await _context.Ofertas.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Oferta> EditarOferta(Oferta i)
        {
            try
            {
                Oferta oferta = _context.Ofertas.Find(i.PkOferta);

                oferta.Descuento = i.Descuento;

                _context.Entry(oferta).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return oferta;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarOferta(int id)
        {
            try
            {
                Oferta oferta = _context.Ofertas.Find(id);

                if (oferta != null)
                {
                    var res = _context.Ofertas.Remove(oferta);
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
