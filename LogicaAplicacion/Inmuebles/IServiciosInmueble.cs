using Compartido.DTOs.Inmueble;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Inmuebles
{
    public interface IServiciosInmueble
    {
        Task<IEnumerable<InmuebleDTO>> SelectInmueblesByFilter(FiltroInmueble filtroInmueble);
        Task<InmuebleDTO> SelectInmuebleById(string inmuebleId);
        Task<InmuebleDTO> InsertInmueble(InmuebleInsertDTO inmueble);
        Task<InmuebleDTO> UpdateInmueble(InmuebleUpdateDTO inmueble);
        Task DeleteInmueble(string inmuebleId);
    }
}
