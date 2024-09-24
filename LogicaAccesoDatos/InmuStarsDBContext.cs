using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class InmuStarsDBContext : DbContext
    {
        public InmuStarsDBContext(DbContextOptions opts) : base(opts) { }

        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Inmueble> Inmuebles { get; set; }
        public DbSet<InmuebleFoto> FotosInmueble { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }
    }
}
