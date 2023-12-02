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
    public class PedidoController : Controller
    {
        //Constructor para el uso de base de datos
        private readonly IPedidoServices _pedidoServices;
        //Se inicia la entrada a base de datos
        private readonly ApplicationDbContext _context;
        public PedidoController(IPedidoServices pedidoServices, ApplicationDbContext context)
        {
            _pedidoServices = pedidoServices;
            _context = context;
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> Index()
        {
            try
            {
                //Uso de la lista de los Usuario para que se muestre al abrir la vista

                return View(await _pedidoServices.GetPedido());

                /*var response = await _articuloServices.GetArticulos();
                return View(response);*/
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> IndexCopia()
        {
            try
            {
                //Uso de la lista de los Usuario para que se muestre al abrir la vista
                return View(await _pedidoServices.GetPedido());
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Clientes = _context.Clientes.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkCliente.ToString()
            });
            ViewBag.Productos = _context.Productos.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkProducto.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Pedido request)
        {
            try
            {
                var response = _pedidoServices.CrearPedido(request);
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
            ViewBag.Clientes = _context.Clientes.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkCliente.ToString()
            });
            ViewBag.Productos = _context.Productos.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkProducto.ToString()
            });
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _pedidoServices.GetByIdPedido(id);

            ViewBag.Clientes = _context.Clientes.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkCliente.ToString()
            });
            ViewBag.Productos = _context.Productos.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkProducto.ToString()
            });
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Pedido request)
        {
            var response = await _pedidoServices.EditarPedido(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _pedidoServices.EliminarPedido(id);
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
