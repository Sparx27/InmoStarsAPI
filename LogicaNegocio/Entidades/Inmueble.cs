using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Table("Inmuebles")]
    public abstract class Inmueble
    {
        public Guid InmuebleId { get; set; }

        public Guid PropietarioId { get; set; }

        [Required(ErrorMessage = "Tipo de operación requerida")]
        [Range(0, 3)]
        public int Propuesta { get; set; }

        public DateTime FechaPublicacion { get; } = DateTime.Now;

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0, 1000000000)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Departamento es requerido")]
        [Range(0, 18)]
        public int Departamento { get; set; }

        [Required(ErrorMessage = "Ciudad es requerida")]
        public string Ciudad { get; set; }

        public string Barrio { get; set; }

        public string Calle { get; set; }

        public string NumeroPuerta { get; set; }

        [Range(1, 99)]
        public int Plantas { get; set; }

        [Range(0, 4)]
        public int Estado { get; set; } // estado(nuevo, reciclado, en_pozo, usado)

        [Range(1700, 2024)]
        public int AnioConstruccion { get; set; }

        [Range(1, 1000000)]
        public decimal M2Edificacods { get; set; }

        [Range(1, 1000000)]
        public decimal M2Totales { get; set; }

        // Navegacion
        [ForeignKey("PropietarioId")]
        public Propietario Propietario { get; set; }

        public Inmueble()
        {

        }
    }
}
