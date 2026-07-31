using System.ComponentModel.DataAnnotations;

namespace CrudGitFlowMVC.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Range(0, 999999)]
        public decimal Precio { get; set; }

        [Range(0, 99999)]
        public int Cantidad { get; set; }

        [StringLength(250)]
        public string? Descripcion { get; set; }
    }
}