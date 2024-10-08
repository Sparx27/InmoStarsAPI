﻿using Compartido.DTOs.Propietario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesExceptions;
using LogicaAplicacion.Utilidades;

namespace LogicaAplicacion.Validadores.Propietario
{
    public static class ValidarPropietario
    {
        public static void Email(string email)
        {
            if (String.IsNullOrEmpty(email) || email.Length > 100 || RegexsTester.TieneEspaciosBlanco(email))
            {
                throw new PropietarioException("El email es obligatorio y de hasta 100 caracteres");
            }
        }

        public static void Contrasena(string contrasena)
        {
            if (String.IsNullOrEmpty(contrasena) ||
                RegexsTester.TieneEspaciosBlanco(contrasena) ||
                !RegexsTester.CumpleFormatoContrasena(contrasena)
            )
            {
                throw new PropietarioException("La contraseña es obligatorio y debe contener: 1 minúscula, mayúcula y número");
            }
        }

        public static void Telefono(string telefono)
        {
            if (String.IsNullOrEmpty(telefono) || telefono.Length > 40)
            {
                throw new PropietarioException("El teléfono es obligatorio y de hasta 40 caracteres");
            }
        }

        public static void Nombre(string nombre)
        {
            if (String.IsNullOrEmpty(nombre) || nombre.Length > 40)
            {
                throw new PropietarioException("El nombre es obligatorio y de hasta 40 caracteres");
            }
        }
    }
}
