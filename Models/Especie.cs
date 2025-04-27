using System.ComponentModel.DataAnnotations;

namespace VeterinariaRepasoParcial.Models
{
    public class Especie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
