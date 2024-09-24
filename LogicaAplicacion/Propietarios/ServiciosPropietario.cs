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
using Compartido.DTOs.Inmueble;

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
            ValidarPropietario.Email(propietarioInsertDTO.Email);
            ValidarPropietario.Contrasena(propietarioInsertDTO.Contrasena);
            ValidarPropietario.Nombre(propietarioInsertDTO.Nombre);
            ValidarPropietario.Telefono(propietarioInsertDTO.Telefono);

            var resDB = await _repositorioPropietarios.InsertPropietario(PropietarioMapper.InsertDTOtoPropietario(propietarioInsertDTO));
            return PropietarioMapper.PropietarioToDTO(resDB);
        }

        public async Task<PropietarioDTO> UpdatePropietario(PropietarioUpdateDTO propietarioUpdateDTO)
        {
            StringsTrimer<PropietarioUpdateDTO>.TrimStrings(propietarioUpdateDTO);

            var (nombre, email, telefono) =
                (propietarioUpdateDTO.Nombre, propietarioUpdateDTO.Email, propietarioUpdateDTO.Telefono);

            ValidarPropietario.Nombre(nombre);
            ValidarPropietario.Email(email);
            ValidarPropietario.Telefono(telefono);

            // Si no lo encuentra, el repositorio lanza un PropietarioException
            var buscarPropietario = await _repositorioPropietarios.SelectPropietarioById(new Guid(propietarioUpdateDTO.PropietarioId));

            buscarPropietario.Nombre = nombre;
            buscarPropietario.Email = email;
            buscarPropietario.Telefono = telefono;

            await _repositorioPropietarios.UpdatePropietario(buscarPropietario);
            return PropietarioMapper.PropietarioToDTO(buscarPropietario);
        }

        public async Task DeletePropietario(string id)
        {
            var buscarUsuario = await _repositorioPropietarios.SelectPropietarioById(new Guid(id));
            await _repositorioPropietarios.DeletePropietario(buscarUsuario);
        }

        public async Task<IEnumerable<InmuebleDTO>> SelectInmueblesPropietario(string propietarioId)
        {
            var buscarPropietario = await _repositorioPropietarios.SelectPropietarioById(new Guid(propietarioId));
            var liInmuebles = await _repositorioPropietarios.SelectInmueblesPropietario(buscarPropietario.PropietarioId);
            return liInmuebles.Select(i => InmuebleMapper.InmuebleToDTO(i));
        }
    }
}
