using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeCraft.Context;
using OfficeCraft.Models;
using OfficeCraft.Services.IService;
using System.Diagnostics;

namespace OfficeCraft.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductoServices _productoServices;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,IProductoServices productoServices, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _productoServices= productoServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _productoServices.GetProducto();
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginUser(string user, string password)
        {

            var response = _context.Usuarios.Include(z => z.Roles)
            .FirstOrDefault(x => x.NombreUsuario == user && x.Contraseña == password);

            if (response != null)
            {
                if (response.Roles.Nombre == "admin")
                {
                    return Json(new { Success = true, admin = true });
                }
                return Json(new { Success = true, admin = false });
            }
            else
            {
                return Json(new { Success = false, admin = false });
            }
        }
    }
}