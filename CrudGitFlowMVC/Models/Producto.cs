using System.ComponentModel.DataAnnotations;

namespace CrudGitFlowMVC.Models
{
    public class Producto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Precio { get; set; }


        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 999999, ErrorMessage = "La cantidad debe ser mayor que 0")]
        public int Cantidad { get; set; }


        [StringLength(250, ErrorMessage = "La descripción no puede superar los 250 caracteres")]
        public string? Descripcion { get; set; }
    }
}