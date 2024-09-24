using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesExceptions;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly InmuStarsDBContext _context;
        public RepositorioPropietario(InmuStarsDBContext context)
        {
            _context = context;
        }

        public async Task<Propietario> SelectPropietarioById(Guid id)
        {
            var propietario = await _context.Propietarios.FirstOrDefaultAsync(p => p.PropietarioId == id);
            if(propietario == null)
            {
                throw new PropietarioException("Usuario no encontrado por Id");
            }
            return propietario;
        }
            
        public async Task<List<Propietario>> SelectPropietarios() =>
            await _context.Propietarios.ToListAsync();

        public async Task<Propietario> InsertPropietario(Propietario propietario)
        {
            await _context.Propietarios.AddAsync(propietario);
            await _context.SaveChangesAsync();
            return propietario;
        }

        public async Task<Propietario> UpdatePropietario(Propietario propietario)
        {
            _context.Propietarios.Update(propietario);
            await _context.SaveChangesAsync();
            return propietario;
        }

        public async Task DeletePropietario(Propietario propietario)
        {
            _context.Propietarios.Remove(propietario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Inmueble>> SelectInmueblesPropietario(Guid propietarioId) =>
            await _context.Inmuebles.Where(i => i.PropietarioId == propietarioId)
                .Include(i => i.Propietario)
                .ToListAsync();
    }
}
