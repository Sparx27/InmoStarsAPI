using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly InmuStarsDBContext _context;
        public RepositorioPropietario(InmuStarsDBContext context)
        {
            _context = context;
        }

        public async Task<Propietario> SelectPropietarioById(Guid id) => 
            await _context.Propietarios.FirstOrDefaultAsync(p => p.PropietarioId == id);

        public async Task<List<Propietario>> SelectPropietarios() =>
            await _context.Propietarios.ToListAsync();

        public async Task<Propietario> InsertPropietario(Propietario propietario)
        {
            await _context.Propietarios.AddAsync(propietario);
            await _context.SaveChangesAsync();
            return propietario;
        }
    }
}
