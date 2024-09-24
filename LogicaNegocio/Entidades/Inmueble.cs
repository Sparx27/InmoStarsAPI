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
    public class Inmueble
    {
        public Guid InmuebleId { get; set; }

        public Guid PropietarioId { get; set; }

        [Required(ErrorMessage = "Tipo de operación requerida")]
        [Range(1, 3)] // 1-Venta, 2-Alquiler, 3-AlquilerTemporal
        public int Propuesta { get; set; }

        public DateTime FechaPublicacion { get; } = DateTime.Now;

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(1, 1000000000)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Departamento es requerido")]
        [Range(1, 19)]
        public int Departamento { get; set; }

        [Required(ErrorMessage = "Ciudad es requerida")]
        public string Ciudad { get; set; }

        public string? Barrio { get; set; }

        public string? Calle { get; set; }

        public string? NumeroPuerta { get; set; }

        [Range(1, 4)]
        public int? Estado { get; set; } // 1-nuevo, 2-usado, 3-en_construccion, 4-reciclado

        [Range(1, 1000000)]
        public decimal? M2Totales { get; set; }


        // Separacion en tipos
        [Required(ErrorMessage = "Tipo de inmueble es requerido")]
        [Range(1, 4, ErrorMessage = "Tipo de inmueble inexistente")]
        public int Tipo { get; set; } // 1-Apartamento, 2-Casa

        [Range(1, 99)]
        public int? Piso { get; set; }

        public string NumeroApartamento { get; set; }

        [Range(1, 99)]
        public int? Dormitorios { get; set; }
        public bool? Balcon { get; set; }
        public bool? Garage { get; set; }
        public bool? Patio { get; set; }

        // Navegacion
        [ForeignKey("PropietarioId")]
        public Propietario Propietario { get; set; }
    }
}
