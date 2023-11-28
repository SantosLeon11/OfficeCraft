using Microsoft.EntityFrameworkCore;
using OfficeCraft.Context;
using OfficeCraft.Models.Entities;
using OfficeCraft.Services.IService;

namespace OfficeCraft.Services.Service
{
    public class ProductoServices: IProductoServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpContextAccessor _httpContext;

        //Constructor para usar las tablas de base de datos
        public ProductoServices(ApplicationDbContext context, IHttpContextAccessor httpContext, IWebHostEnvironment webHost)
        {
            _context = context;
            _httpContext = httpContext;
            _webHost = webHost;
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
                var urlImagen = i.Img.FileName;
                i.UrlImagenPath = @"Img/articulos/" + urlImagen;
                Producto request = new Producto()
                {
                    Nombre = i.Nombre,
                    Precio = i.Precio,
                    Existencia = i.Existencia,
                    UrlImagenPath = i.UrlImagenPath,
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
        public bool SubirImg(string Img)
        {
            bool res = false;

            try
            {
                string rutaprincipal = _webHost.WebRootPath;
                var archivos = _httpContext.HttpContext.Request.Form.Files;

                if (archivos.Count > 0 && !string.IsNullOrEmpty(archivos[0].FileName))
                {

                    var nombreArchivo = Img;
                    var subidas = Path.Combine(rutaprincipal, "Img", "Productos");

                    // Asegurarse de que el directorio de destino exista
                    if (!Directory.Exists(subidas))
                    {
                        Directory.CreateDirectory(subidas);
                    }

                    var rutaCompleta = Path.Combine(subidas, nombreArchivo);

                    using (var fileStream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStream);
                        res = true;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al subir la imagen: {ex.Message}");
            }

            return res;
        }
    }
}
