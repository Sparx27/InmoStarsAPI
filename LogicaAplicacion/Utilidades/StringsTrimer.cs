using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Utilidades
{
    public static class StringsTrimer<T>
    {
        public static void TrimStrings(T obj)
        {
            var atributosString = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(string) && p.CanWrite && p.CanRead);

            foreach(var prop in atributosString)
            {
                var valorProp = (string)prop.GetValue(obj);
                if(valorProp != null)
                {
                    prop.SetValue(obj, valorProp.Trim());
                }
            }
        }
    }
}
