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
        public DbSet<Casa> Casas { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<InmuebleFoto> FotosInmueble { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inmueble>()
                .ToTable("Inmuebles");  // Tabla base

            modelBuilder.Entity<Casa>()
                .ToTable("Casas");  // Tabla específica para casas

            modelBuilder.Entity<Apartamento>()
                .ToTable("Apartamentos");  // Tabla específica para apartamentos
        }
    }
}
