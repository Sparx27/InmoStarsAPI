using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class FiltroInmueble
    {
        public int? Tipo { get; set; } // 1 - Casa, 2 - Apartamento, etc
        //[Range(0, 3)]
        public int? Propuesta { get; set; }
        public decimal? Precio { get; set; }

        //[Range(0, 18)]
        public int? Departamento { get; set; }
        public string? Ciudad { get; set; }
        public string? Barrio { get; set; }

        //[Range(1, 99)]
        public int? Plantas { get; set; }

        //[Range(0, 4)]
        public int? Estado { get; set; } // estado(nuevo, reciclado, en_pozo, usado)

        //[Range(1700, 2024)]
        public int? AnioConstruccion { get; set; }

        //[Range(1, 1000000)]
        public decimal? M2Edificacods { get; set; }

        //[Range(1, 1000000)]
        public decimal? M2Totales { get; set; }
    }
}
