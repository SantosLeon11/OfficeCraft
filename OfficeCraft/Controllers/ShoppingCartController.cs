using Microsoft.AspNetCore.Mvc;
using OfficeCraft.Models.Entities;

namespace OfficeCraft.Controllers
{
    public class ShoppingCartController : Controller
    {
        private List<ShoppingCartItem> ShoppingCart = new List<ShoppingCartItem>();

        // Acción para mostrar el carrito
        public ActionResult Index()
        {
            return View(ShoppingCart);
        }

        // Acción para agregar un producto al carrito
        public ActionResult AddToCart(Producto product)
        {
            var existingItem = ShoppingCart.FirstOrDefault(item => item.Product.PkProducto == product.PkProducto);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                ShoppingCart.Add(new ShoppingCartItem { Product = product, Quantity = 1 });
            }

            return RedirectToAction("Cart");
        }

        // Acción para eliminar un producto del carrito
        public ActionResult RemoveFromCart(int productId)
        {
            ShoppingCart.RemoveAll(item => item.Product.PkProducto == productId);
            return RedirectToAction("Cart");
        }

        // Otras acciones para aumentar o disminuir la cantidad si es necesario
        // ...

        // Acción para procesar el pedido
        public ActionResult Checkout()
        {
            // Aquí puedes generar el código aleatorio de 6 dígitos
            var orderCode = GenerateOrderCode();

            ViewBag.OrderCode = orderCode;

            return View();
        }

        private string GenerateOrderCode()
        {
            // Lógica para generar un código aleatorio de 6 dígitos
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}
