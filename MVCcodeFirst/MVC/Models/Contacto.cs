using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Contacto
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligario. Ingrese algun Nombre.")]
        public string Nombre { get; set; }

        public string CorreoElectronico { get; set; }

        public string Direccion { get; set; }
    }
}
