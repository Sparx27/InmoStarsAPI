using Compartido.DTOs.Inmueble;
using LogicaNegocio.Entidades;
using LogicaNegocio.EntidadesExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public static class InmuebleMapper
    {
        private static string IdAPropuesta(int id)
        {
            // 1-Venta, 2-Alquiler, 3-AlquilerTemporal
            string res = "";
            if (id == 1) res = "Venta";
            else if (id == 2) res = "Alquiler";
            else if (id == 3) res = "Alquiler Temporal";
            else if (id == 4) res = "Otro";
            return res;
        }

        private static string IdADepartamento(int id)
        {
            string res = "";
            if (id == 1) res = "Montevideo";
            else if (id == 2) res = "Canelones";
            else if (id == 3) res = "Maldonado";
            else if (id == 4) res = "Cerro Largo";
            else if (id == 5) res = "Rocha";
            return res;
        }

        private static string? IdAEstado(int? id)
        {
            if(id == null) return null;

            // 1-nuevo, 2-usado, 3-en_construccion, 4-reciclado
            string res = "";
            if (id == 1) res = "Nuevo";
            else if (id == 2) res = "Usado";
            else if (id == 3) res = "En Construcción";
            else if (id == 4) res = "Reciclado";
            return res;
        }

        private static string IdATipo(int id)
        {
            // 1-Apartamento, 2-Casa, 3-Local, 4-Garage
            string res = "";
            if (id == 1) res = "Apartamento";
            else if (id == 2) res = "Casa";
            else if (id == 3) res = "Local";
            else if (id == 4) res = "Garage";
            return res;
        }

        public static InmuebleDTO InmuebleToDTO(Inmueble inmueble)
        {
            if(inmueble == null)
            {
                throw new InmuebleException("Inmueble vacío en mapper");
            }

            // Apartamento
            if(inmueble.Tipo == 1)
            {
                return new InmuebleDTO
                {
                    InmuebleId = inmueble.InmuebleId.ToString(),
                    PropietarioId = inmueble.PropietarioId.ToString(),
                    Propuesta = IdAPropuesta(inmueble.Propuesta),
                    FechaPublicacion = inmueble.FechaPublicacion,
                    Precio = inmueble.Precio,
                    Departamento = IdADepartamento(inmueble.Departamento),
                    Ciudad = inmueble.Ciudad,
                    Barrio = inmueble.Barrio,
                    Calle = inmueble.Calle,
                    NumeroPuerta = inmueble.NumeroPuerta,
                    Estado = IdAEstado(inmueble.Estado),
                    M2Totales = inmueble.M2Totales,
                    Tipo = IdATipo(inmueble.Tipo),
                    Piso = inmueble.Piso,
                    NumeroApartamento = inmueble.NumeroApartamento,
                    Dormitorios = inmueble.Dormitorios,
                    Balcon = inmueble.Balcon,
                    Garage = inmueble.Garage,
                    Patio = inmueble.Patio
                };
            }

            // Casa
            if(inmueble.Tipo == 2)
            {
                return new InmuebleDTO
                {
                    InmuebleId = inmueble.InmuebleId.ToString(),
                    PropietarioId = inmueble.PropietarioId.ToString(),
                    Propuesta = IdAPropuesta(inmueble.Propuesta),
                    FechaPublicacion = inmueble.FechaPublicacion,
                    Precio = inmueble.Precio,
                    Departamento = IdADepartamento(inmueble.Departamento),
                    Ciudad = inmueble.Ciudad,
                    Barrio = inmueble.Barrio,
                    Calle = inmueble.Calle,
                    NumeroPuerta = inmueble.NumeroPuerta,
                    Estado = IdAEstado(inmueble.Estado),
                    M2Totales = inmueble.M2Totales,
                    Tipo = IdATipo(inmueble.Tipo),
                    Piso = inmueble.Piso,
                    Dormitorios = inmueble.Dormitorios,
                    Balcon = inmueble.Balcon,
                    Garage = inmueble.Garage,
                    Patio = inmueble.Patio
                };
            }

            // Local
            if(inmueble.Tipo == 3)
            {
                return new InmuebleDTO
                {
                    InmuebleId = inmueble.InmuebleId.ToString(),
                    PropietarioId = inmueble.PropietarioId.ToString(),
                    Propuesta = IdAPropuesta(inmueble.Propuesta),
                    FechaPublicacion = inmueble.FechaPublicacion,
                    Precio = inmueble.Precio,
                    Departamento = IdADepartamento(inmueble.Departamento),
                    Ciudad = inmueble.Ciudad,
                    Barrio = inmueble.Barrio,
                    Calle = inmueble.Calle,
                    NumeroPuerta = inmueble.NumeroPuerta,
                    Estado = IdAEstado(inmueble.Estado),
                    M2Totales = inmueble.M2Totales,
                    Tipo = IdATipo(inmueble.Tipo),
                    Piso = inmueble.Piso,
                    Balcon = inmueble.Balcon,
                    Garage = inmueble.Garage,
                    Patio = inmueble.Patio
                };
            }

            //// Garage
            //if(inmueble.Tipo == 4)
            //{
            //    return new InmuebleDTO
            //    {
            //        InmuebleId = inmueble.InmuebleId.ToString(),
            //        PropietarioId = inmueble.PropietarioId.ToString(),
            //        Propuesta = IdAPropuesta(inmueble.Propuesta),
            //        FechaPublicacion = inmueble.FechaPublicacion,
            //        Precio = inmueble.Precio,
            //        Departamento = IdADepartamento(inmueble.Departamento),
            //        Ciudad = inmueble.Ciudad,
            //        Barrio = inmueble.Barrio,
            //        Calle = inmueble.Calle,
            //        NumeroPuerta = inmueble.NumeroPuerta,
            //        Estado = IdAEstado(inmueble.Estado),
            //        M2Totales = inmueble.M2Totales,
            //        Tipo = IdATipo(inmueble.Tipo)
            //    };
            //}

            throw new InmuebleException("Tipo de inmueble incorrecto en mapper");
        }

        public static Inmueble InsertDTOtoInmueble(InmuebleInsertDTO inmuebleInsertDTO)
        {
            if(inmuebleInsertDTO == null)
            {
                throw new InmuebleException("Inmueble DTO vacío en mapper");
            }

            // Apartamento
            if(inmuebleInsertDTO.Tipo == 1)
            {
                return new Inmueble
                {
                    PropietarioId = new Guid(inmuebleInsertDTO.PropietarioId),
                    Propuesta = inmuebleInsertDTO.Propuesta,
                    Precio = inmuebleInsertDTO.Precio,
                    Departamento = inmuebleInsertDTO.Departamento,
                    Ciudad = inmuebleInsertDTO.Ciudad,
                    Barrio = inmuebleInsertDTO.Barrio,
                    Calle = inmuebleInsertDTO.Calle,
                    NumeroPuerta = inmuebleInsertDTO.NumeroPuerta,
                    Estado = inmuebleInsertDTO.Estado,
                    M2Totales = inmuebleInsertDTO.M2Totales,
                    Tipo = inmuebleInsertDTO.Tipo,
                    Piso = inmuebleInsertDTO.Piso,
                    NumeroApartamento = inmuebleInsertDTO.NumeroApartamento,
                    Dormitorios = inmuebleInsertDTO.Dormitorios,
                    Balcon = inmuebleInsertDTO.Balcon,
                    Garage = inmuebleInsertDTO.Garage,
                    Patio = inmuebleInsertDTO.Patio
                };
            }

            // Casa
            if(inmuebleInsertDTO.Tipo == 2)
            {
                return new Inmueble
                {
                    PropietarioId = new Guid(inmuebleInsertDTO.PropietarioId),
                    Propuesta = inmuebleInsertDTO.Propuesta,
                    Precio = inmuebleInsertDTO.Precio,
                    Departamento = inmuebleInsertDTO.Departamento,
                    Ciudad = inmuebleInsertDTO.Ciudad,
                    Barrio = inmuebleInsertDTO.Barrio,
                    Calle = inmuebleInsertDTO.Calle,
                    NumeroPuerta = inmuebleInsertDTO.NumeroPuerta,
                    Estado = inmuebleInsertDTO.Estado,
                    M2Totales = inmuebleInsertDTO.M2Totales,
                    Tipo = inmuebleInsertDTO.Tipo,
                    Dormitorios = inmuebleInsertDTO.Dormitorios,
                    Garage = inmuebleInsertDTO.Garage,
                    Patio = inmuebleInsertDTO.Patio
                };
            }

            // Local
            if(inmuebleInsertDTO.Tipo == 3)
            {
                return new Inmueble
                {
                    PropietarioId = new Guid(inmuebleInsertDTO.PropietarioId),
                    Propuesta = inmuebleInsertDTO.Propuesta,
                    Precio = inmuebleInsertDTO.Precio,
                    Departamento = inmuebleInsertDTO.Departamento,
                    Ciudad = inmuebleInsertDTO.Ciudad,
                    Barrio = inmuebleInsertDTO.Barrio,
                    Calle = inmuebleInsertDTO.Calle,
                    NumeroPuerta = inmuebleInsertDTO.NumeroPuerta,
                    Estado = inmuebleInsertDTO.Estado,
                    M2Totales = inmuebleInsertDTO.M2Totales,
                    Tipo = inmuebleInsertDTO.Tipo,
                    Garage = inmuebleInsertDTO.Garage,
                    Patio = inmuebleInsertDTO.Patio
                };
            }

            throw new InmuebleException("Tipo de inmueble incorrecto en mapper");
        }
    }
}
