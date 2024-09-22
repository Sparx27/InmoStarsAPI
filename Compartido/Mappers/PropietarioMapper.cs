using Compartido.DTOs.Propietario;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesExceptions;

namespace Compartido.Mappers
{
    public static class PropietarioMapper
    {
        public static PropietarioDTO PropietarioToDTO(Propietario propietario)
        {
            if(propietario == null)
            {
                throw new PropietarioException("Propietario null en mapper");
            }
            return new PropietarioDTO
            {
                PropietarioId = propietario.PropietarioId.ToString(),
                Nombre = propietario.Nombre,
                Email = propietario.Email,
                Telefono = propietario.Telefono
            };
        }

        public static Propietario InsertDTOtoPropietario(PropietarioInsertDTO propietarioInsertDTO)
        {
            if (propietarioInsertDTO == null)
            {
                throw new PropietarioException("Propietario Insert null en mapper");
            }
            return new Propietario
            {
                Email = propietarioInsertDTO.Email,
                Nombre = propietarioInsertDTO.Nombre,
                Contrasena = propietarioInsertDTO.Contrasena,
                Telefono = propietarioInsertDTO.Telefono
            };
        }

        public static PropietarioDTO DTOtoPropietario(Propietario propietario)
        {
            if(propietario == null)
            {
                throw new PropietarioException("Propietario null en mapper");
            }
            return new PropietarioDTO
            {
                PropietarioId = propietario.PropietarioId.ToString(),
                Email = propietario.Email,
                Nombre = propietario.Nombre,
                Telefono = propietario.Telefono
            };
        }
    }
}
