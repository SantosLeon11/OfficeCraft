using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeCraft.Models.Entities
{
    public class Pedido
    {
        [Key]
        public int PkPedido { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaPedido { get; set; }
        [ForeignKey("Cliente")]
        public int FkCliente { get; set; }
        public Cliente Clientes { get; set; }
        [ForeignKey("Producto")]
        public int FkProducto { get; set; }
        public Producto Productos { get; set; }
    }
}
