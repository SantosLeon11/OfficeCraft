using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeCraft.Models.Entities
{
    public class Oferta
    {
        [Key]
        public int PkOferta { get; set; }
        public int Descuento { get; set; }

        [ForeignKey("Productos")]
        public int? FkProducto { get; set; }
        public Producto Productos { get; set; }
    }
}
