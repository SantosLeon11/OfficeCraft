using Microsoft.AspNetCore.Mvc;
using OfficeCraft.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeCraft.Controllers
{
    public class ShoppingCartController : Controller
    {
        private static List<Producto> ShoppingCart = new List<Producto>();

        [HttpGet]
        public ActionResult Index()
        {
            return View(ShoppingCart);
        }

        [HttpPost]
        public ActionResult AddToCart(Producto product)
        {
            var existingItem = ShoppingCart.FirstOrDefault(item => item.PkProducto == product.PkProducto);

            if (existingItem != null)
            {
                existingItem.Existencia++;
            }
            else
            {
                ShoppingCart.Add(new Producto { PkProducto = product.PkProducto, Nombre = product.Nombre, Precio = product.Precio, Existencia = 1 });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Cart()
        {
            return View(ShoppingCart);
        }

        // Resto de las acciones...

        private string GenerateOrderCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}