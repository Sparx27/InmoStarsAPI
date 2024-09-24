using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Inmueble
{
    public class InmuebleDTO
    {
        public string InmuebleId { get; set; } = null!;
        public string PropietarioId { get; set; } = null!;
        public string Propuesta { get; set; } // 1-Venta, 2-Alquiler, 3-AlquilerTemporal
        public DateTime FechaPublicacion { get; set;  }
        public decimal Precio { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string? Barrio { get; set; }
        public string? Calle { get; set; }
        public string? NumeroPuerta { get; set; }
        public string Estado { get; set; } // 1-nuevo, 2-usado, 3-en_construccion, 4-reciclado
        public decimal? M2Totales { get; set; }


        // Separacion en tipos
        public string Tipo { get; set; } = null!; // 1-Apartamento, 2-Casa, 3-Local, 4-Garage
        public int? Piso { get; set; }
        public string NumeroApartamento { get; set; }
        public int? Dormitorios { get; set; }
        public bool? Balcon { get; set; }
        public bool? Garage { get; set; }
        public bool? Patio { get; set; }

        // Propiedades de Propietario
        public string PropietarioNombre { get; set; }
        public string PropietarioTelefono { get; set; }
    }
}
