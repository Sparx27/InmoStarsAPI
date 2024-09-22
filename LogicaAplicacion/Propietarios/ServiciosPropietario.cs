using Compartido.DTOs.Propietario;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.Mappers;
using LogicaAplicacion.Utilidades;
using LogicaAplicacion.Validadores.Propietario;

namespace LogicaAplicacion.Propietarios
{
    public class ServiciosPropietario : IServiciosPropietario
    {
        private readonly IRepositorioPropietario _repositorioPropietarios;
        public ServiciosPropietario(IRepositorioPropietario repositorioPropietarios)
        {
            _repositorioPropietarios = repositorioPropietarios;
        }

        public async Task<PropietarioDTO> GetPropietarioById(string id) =>
            PropietarioMapper.PropietarioToDTO(await _repositorioPropietarios.SelectPropietarioById(new Guid(id)));

        public async Task<IEnumerable<PropietarioDTO>> GetPropietarios()
        {
            var resDB = await _repositorioPropietarios.SelectPropietarios();
            return resDB.Select(p => PropietarioMapper.PropietarioToDTO(p));
        }

        public async Task<PropietarioDTO> InsertPropietario(PropietarioInsertDTO propietarioInsertDTO)
        {
            StringsTrimer<PropietarioInsertDTO>.TrimStrings(propietarioInsertDTO);
            ValidarPropietario.ValidarInsert(propietarioInsertDTO);

            var resDB = await _repositorioPropietarios.InsertPropietario(PropietarioMapper.InsertDTOtoPropietario(propietarioInsertDTO));
            return PropietarioMapper.PropietarioToDTO(resDB);
        }
            
    }
}
