using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaRepasoParcial.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdEspecie { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="El valor debe ser mayor o igual a 0")]
        public int Edad { get; set; }
        [Required]
        [DisplayName("Nombre del Dueño")]
        public string NombreDuenio { get; set; }
        public Especie? Especie { get; set; }
        
    }
}
