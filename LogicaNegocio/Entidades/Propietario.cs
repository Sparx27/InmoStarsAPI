using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Table("Propietarios")]
    public class Propietario
    {
        public Guid PropietarioId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Contrasena { get; set; }

        [Required]
        [MaxLength(40)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(40)]
        public string Telefono { get; set; }

        // Navegacion
        public ICollection<Inmueble> Inmuebles { get; set; }

    }
}
