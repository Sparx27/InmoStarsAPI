using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Table("Casas")]
    public class Casa : Inmueble
    {
        [Range(0,99)]
        public int Dormitorios { get; set; }

        [Range(0, 99)]
        public int Banios { get; set; }

        public bool Balcon {  get; set; }
        public bool Garage { get; set; }
        public bool Patio { get; set; }
        public bool Barbacoa { get; set; }
    }
}
