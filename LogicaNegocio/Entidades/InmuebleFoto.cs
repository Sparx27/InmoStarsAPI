using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Table("InmuebleFotos")]
    public class InmuebleFoto
    {
        public Guid InmuebleFotoId { get; set; }
        public Guid InmuebleId { get; set; }

        [Required(ErrorMessage = "Path de la foto requerida")]
        public string CarpetaPath { get; set; }
    }
}
