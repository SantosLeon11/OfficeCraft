using System.ComponentModel.DataAnnotations;

namespace OfficeCraft.Models.Entities
{
    public class Producto
    {
        [Key]
        public int PkProducto { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Existencia { get; set; }
    }
}
