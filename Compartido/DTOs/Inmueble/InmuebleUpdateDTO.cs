using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Inmueble
{
    public class InmuebleUpdateDTO
    {
        public string InmuebleId { get; set; }
        public int Propuesta { get; set; }
        public decimal Precio { get; set; }
        public int Departamento { get; set; }
        public string Ciudad { get; set; }
        public string? Barrio { get; set; }
        public string? Calle { get; set; }
        public string? NumeroPuerta { get; set; }
        public int? Estado { get; set; } // 1-nuevo, 2-usado, 3-en_construccion, 4-reciclado
        public decimal? M2Totales { get; set; }


        // Separacion en tipos
        public int Tipo { get; set; } // 1-Apartamento, 2-Casa
        public int? Piso { get; set; }
        public string NumeroApartamento { get; set; }
        public int? Dormitorios { get; set; }
        public bool? Balcon { get; set; }
        public bool? Garage { get; set; }
        public bool? Patio { get; set; }
    }
}
