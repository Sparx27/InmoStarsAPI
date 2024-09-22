using Compartido.DTOs.Propietario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Propietarios
{
    public interface IServiciosPropietario
    {
        Task<IEnumerable<PropietarioDTO>> GetPropietarios();
        Task<PropietarioDTO> GetPropietarioById(string id);
        Task<PropietarioDTO> InsertPropietario(PropietarioInsertDTO propietarioInsertDTO);
        Task<PropietarioDTO> UpdatePropietario(PropietarioUpdateDTO propietarioUpdateDTO);
        Task DeletePropietario(string id);
    }
}
