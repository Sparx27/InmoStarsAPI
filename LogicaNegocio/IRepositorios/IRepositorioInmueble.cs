using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.IRepositorios
{
    public interface IRepositorioInmueble
    {
        Task<List<Inmueble>> SelectInmueblesByFilter(FiltroInmueble filtroInmueble);
        Task<Inmueble> SelectInmuebleById(Guid id);
        Task<Inmueble> InsertInmueble(Inmueble inmueble);
        Task<Inmueble> UpdateInmueble(Inmueble inmueble);
        Task DeleteInmueble(Inmueble inmueble);
    }
}
