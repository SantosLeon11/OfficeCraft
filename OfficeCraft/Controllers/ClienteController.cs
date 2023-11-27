using Microsoft.AspNetCore.Mvc;
using OfficeCraft.Models.Entities;
using OfficeCraft.Services.IService;
using OfficeCraft.Services.Service;

namespace OfficeCraft.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;
        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _clienteServices.GetCliente());

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
        public IActionResult Crear(Cliente request)
        {
            try
            {
                var response = _clienteServices.CrearCliente(request);
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
            var response = await _clienteServices.GetByIdCliente(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Editar(Cliente request)
        {
            var response = _clienteServices.EditarCliente(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _clienteServices.EliminarCliente(id);
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
