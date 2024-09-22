using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.IRepositorios
{
    public interface IRepositorioPropietario
    {
        Task<List<Propietario>> SelectPropietarios();
        Task<Propietario> SelectPropietarioById(Guid id);
        Task<Propietario> InsertPropietario(Propietario propietario);
        Task<Propietario> UpdatePropietario(Propietario propietario);
        Task DeletePropietario(Propietario propietario);
    }
}
