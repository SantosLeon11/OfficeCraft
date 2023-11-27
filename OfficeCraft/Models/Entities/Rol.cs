using System.ComponentModel.DataAnnotations;

namespace OfficeCraft.Models.Entities
{
    public class Rol
    {
        [Key]
        public int PkRoles { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
