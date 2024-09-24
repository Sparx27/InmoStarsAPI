using Compartido.DTOs.Inmueble;
using Compartido.Mappers;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Inmuebles
{
    public class ServiciosInmueble : IServiciosInmueble
    {
        private readonly IRepositorioInmueble _repositorioInmueble;
        public ServiciosInmueble(IRepositorioInmueble repositorioInmueble)
        {
            _repositorioInmueble = repositorioInmueble;
        }

        public async Task<IEnumerable<InmuebleDTO>> SelectInmueblesByFilter(FiltroInmueble filtroInmueble)
        {
            var resDB = await _repositorioInmueble.SelectInmueblesByFilter(filtroInmueble);
            return resDB.Select(i => InmuebleMapper.InmuebleToDTO(i));
        }

        public async Task<InmuebleDTO> SelectInmuebleById(string inmuebleId) => 
            InmuebleMapper.InmuebleToDTO(await _repositorioInmueble.SelectInmuebleById(new Guid(inmuebleId)));

        public async Task<InmuebleDTO> InsertInmueble(InmuebleInsertDTO inmuebleInsertDTO)
        {
            // Faltan validaciones

            var resDB = await _repositorioInmueble.InsertInmueble(InmuebleMapper.InsertDTOtoInmueble(inmuebleInsertDTO));
            return InmuebleMapper.InmuebleToDTO(resDB);
        }

        public async Task<InmuebleDTO> UpdateInmueble(InmuebleUpdateDTO inmuebleUpdateDTO)
        {
            // Faltan validaciones

            // Inlcuido que propietario logueado ID = inmuebleUpdateDTO.Id
            // 1) Se busca inmueble, 2) Se compara ID del Token con IDPropietario de 1)

            var buscarInmueble = await _repositorioInmueble.SelectInmuebleById(new Guid(inmuebleUpdateDTO.InmuebleId));


            // Reflección para hacer el update automático

            // 1) Atributos que no se actualizan, HashSet porque es mas eficiente en buscar
            var atributosExcluidas = new HashSet<string>() { "PropietarioId" };

            // 2) Atributos públicos del DTO
            var atributosDTO = typeof(InmuebleUpdateDTO).GetProperties();

            // 3) Iterar sobre atributos del DTO y reemplazarlas en Inmueble (buscarInmueble)
            foreach(var atrDTO in atributosDTO)
            {
                if (atributosExcluidas.Contains(atrDTO.Name)) continue;

                // Encontrar el atributo en Inmueble que sea igual al atributo DTO
                var atrInmueble = typeof(Inmueble).GetProperty(atrDTO.Name);

                if(atrInmueble != null && atrInmueble.CanWrite)
                {
                    // Valor del DTO que ingresó en la iteración
                    var atrDTOValue = atrDTO.GetValue(inmuebleUpdateDTO);

                    // Reemplaza ese valor en la instancia de Inmueble
                    atrInmueble.SetValue(buscarInmueble, atrDTOValue);
                }
            }

            var resDB = await _repositorioInmueble.UpdateInmueble(buscarInmueble);
            return InmuebleMapper.InmuebleToDTO(buscarInmueble);
        }

        public async Task DeleteInmueble(string inmuebleId)
        {
            var buscarInmueble = await _repositorioInmueble.SelectInmuebleById(new Guid(inmuebleId));
            await _repositorioInmueble.DeleteInmueble(buscarInmueble);
        }
    }
}
