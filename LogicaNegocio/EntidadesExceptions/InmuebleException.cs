using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesExceptions
{
    public class InmuebleException : Exception
    {
        public InmuebleException() { }
        public InmuebleException(string message) : base(message) { }
        public InmuebleException(string message, Exception innerException) : base(message, innerException) { }
    }
}
