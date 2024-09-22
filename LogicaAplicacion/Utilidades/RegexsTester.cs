using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaAplicacion.Utilidades
{
    public static partial class RegexsTester
    {
        [GeneratedRegex(@"[\s]+")]
        private static partial Regex EspaciosBlancoRegex();

        [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{6,}$")]
        private static partial Regex ContrasenaRegex();

        // Metodos de clase
        public static bool TieneEspaciosBlanco(string valor) => EspaciosBlancoRegex().IsMatch(valor);

        public static bool CumpleFormatoContrasena(string valor) => ContrasenaRegex().IsMatch(valor);
    }
}
