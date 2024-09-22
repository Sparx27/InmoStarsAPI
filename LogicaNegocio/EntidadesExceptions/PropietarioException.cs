using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesExceptions
{
    public class PropietarioException : Exception
    {
        public PropietarioException() { }
        public PropietarioException(string message) : base(message) { }
        public PropietarioException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}
