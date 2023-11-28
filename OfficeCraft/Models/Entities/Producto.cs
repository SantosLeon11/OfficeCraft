using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeCraft.Models.Entities
{
    public class Producto
    {
        [Key]
        public int PkProducto { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Existencia { get; set; }
        [NotMapped]
        [Display(Name = "Image")]
        public IFormFile Img { get; set; }
        public string UrlImagenPath { get; set; }
    }
}
