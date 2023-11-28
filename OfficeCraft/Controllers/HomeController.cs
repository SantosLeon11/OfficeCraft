using Microsoft.AspNetCore.Mvc;
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
    }
}