using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.EntidadesExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioInmueble : IRepositorioInmueble
    {
        private readonly InmuStarsDBContext _context;
        public RepositorioInmueble(InmuStarsDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Inmueble>> SelectInmueblesByFilter(FiltroInmueble filtroInmueble)
        {
            IQueryable<Inmueble> query = _context.Inmuebles;

            var (tipo, propuesta, precio, departamento, ciudad, barrio, plantas, estado, anioConstruccion, m2Edificados, m2Totales) =
                (filtroInmueble.Tipo, filtroInmueble.Propuesta, filtroInmueble.Precio, filtroInmueble.Departamento, filtroInmueble.Ciudad,
                filtroInmueble.Barrio, filtroInmueble.Plantas, filtroInmueble.Estado, filtroInmueble.AnioConstruccion, filtroInmueble.M2Edificacods,
                filtroInmueble.M2Totales);

            if (tipo.HasValue)
            {
                query = query.Where(i => i.Tipo == tipo);
            }

            if(propuesta.HasValue)
            {
                query = query.Where(i => i.Propuesta == propuesta);
            }

            if(precio.HasValue)
            {
                query = query.Where(i => i.Precio <= precio);
            }

            if(departamento.HasValue)
            {
                query = query.Where(i => i.Departamento == departamento);
            }

            if(!String.IsNullOrEmpty(ciudad))
            {
                query = query.Where(i => i.Ciudad == ciudad.ToLower());
            }

            if(!String.IsNullOrEmpty(barrio))
            {
                query = query.Where(i => i.Barrio == barrio.ToLower());
            }

            if(estado.HasValue)
            {
                query = query.Where(i => i.Estado == estado);
            }

            if(m2Totales.HasValue)
            {
                query = query.Where(i => i.M2Totales <=  m2Totales);
            }

            // Ejecuta la consulta y retorna los resultados
            return await query.Include(i => i.Propietario).ToListAsync();
        }

        public async Task<Inmueble> SelectInmuebleById(Guid inmuebleId)
        {
            var buscarInmueble = await _context.Inmuebles.Include(i => i.Propietario).FirstOrDefaultAsync(i => i.InmuebleId == inmuebleId);
            if(buscarInmueble == null)
            {
                throw new InmuebleException("No se encontró el inmueble");
            }
            return buscarInmueble;
        }

        public async Task<Inmueble> InsertInmueble(Inmueble inmueble)
        {
            await _context.Inmuebles.AddAsync(inmueble);
            await _context.SaveChangesAsync();
            return inmueble;
        }

        public async Task<Inmueble> UpdateInmueble(Inmueble inmueble)
        {
            _context.Inmuebles.Update(inmueble);
            await _context.SaveChangesAsync();
            return inmueble;
        }

        public async Task DeleteInmueble(Inmueble inmueble)
        {
            _context.Inmuebles.Remove(inmueble);
            await _context.SaveChangesAsync();
        }
        
    }
}
