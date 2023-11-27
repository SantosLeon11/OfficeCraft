using System.ComponentModel.DataAnnotations;

namespace OfficeCraft.Models.Entities
{
    public class Cliente
    {
        [Key]
        public int PkCliente { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
