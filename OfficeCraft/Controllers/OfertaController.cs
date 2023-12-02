using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeCraft.Context;
using OfficeCraft.Models.Entities;
using OfficeCraft.Services.IService;
using OfficeCraft.Services.Service;

namespace OfficeCraft.Controllers
{
    public class OfertaController : Controller
    {
        //Constructor para el uso de base de datos
        private readonly IOfertaServices _ofertaServices;
        //Se inicia la entrada a base de datos
        private readonly ApplicationDbContext _context;
        public OfertaController(IOfertaServices ofertaServices, ApplicationDbContext context)
        {
            _ofertaServices = ofertaServices;
            _context = context;
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> Index()
        {
            try
            {
                //Uso de la lista de los Usuario para que se muestre al abrir la vista

                return View(await _ofertaServices.GetOferta());

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
            ViewBag.Productos = _context.Productos.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkProducto.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Oferta request)
        {
            try
            {
                var response = _ofertaServices.CrearOferta(request);
                //Esta funcion return sirve para volver al index despues de la accion
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Error" + ex.Message);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _ofertaServices.GetByIdOferta(id);

            ViewBag.Productos = _context.Productos.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkProducto.ToString()
            });
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Oferta request)
        {
            var response = await _ofertaServices.EditarOferta(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _ofertaServices.EliminarOferta(id);
            if (true)
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
