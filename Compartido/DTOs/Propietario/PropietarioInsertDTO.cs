using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Propietario
{
    public class PropietarioInsertDTO
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
