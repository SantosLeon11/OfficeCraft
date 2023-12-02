using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeCraft.Context;
using OfficeCraft.Models.Entities;
using OfficeCraft.Services.IService;
using OfficeCraft.Services.Service;
using System.Data;

namespace OfficeCraft.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoServices _productoServices;
        public ProductoController(IProductoServices productoServices)
        {
            _productoServices = productoServices;
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _productoServices.GetProducto());
                //var response = await _context.Database.GetDbConnection().QueryAsync<Producto>("SpGetArticulos", new { }, commandType: CommandType.StoredProcedure);
                //return response.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }
        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> IndexCopia()
        {
            try
            {
                return View(await _productoServices.GetProducto());

                /*var response = await _articuloServices.GetArticulos();
                return View(response);*/
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Producto request)
        {
            try
            {
                var response = _productoServices.CrearProducto(request);
                //Esta funcion return sirve para volver al index despues de la accion
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Error" + ex.Message);
            }
        }
        [HttpGet]
        public IActionResult CrearCopia()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _productoServices.GetByIdProducto(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Editar(Producto request)
        {
            var response = _productoServices.EditarProducto(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _productoServices.EliminarProducto(id);
            if (result = true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }
        }
    }
}
