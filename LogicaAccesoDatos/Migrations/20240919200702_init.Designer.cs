﻿// <auto-generated />
using System;
using LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(InmuStarsDBContext))]
    [Migration("20240919200702_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("LogicaNegocio.Entidades.Inmueble", b =>
                {
                    b.Property<Guid>("InmuebleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AnioConstruccion")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Barrio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Departamento")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("M2Edificacods")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("M2Totales")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroPuerta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Plantas")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropietarioId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Propuesta")
                        .HasColumnType("INTEGER");

                    b.HasKey("InmuebleId");

                    b.HasIndex("PropietarioId");

                    b.ToTable("Inmuebles", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.InmuebleFoto", b =>
                {
                    b.Property<Guid>("InmuebleFotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CarpetaPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InmuebleId")
                        .HasColumnType("TEXT");

                    b.HasKey("InmuebleFotoId");

                    b.ToTable("InmuebleFotos");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Propietario", b =>
                {
                    b.Property<Guid>("PropietarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.HasKey("PropietarioId");

                    b.ToTable("Propietarios");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Apartamento", b =>
                {
                    b.HasBaseType("LogicaNegocio.Entidades.Inmueble");

                    b.Property<bool>("Balcon")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Banios")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Barbacoa")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Dormitorios")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Garage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumeroApartamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Patio")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Piso")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Porteria")
                        .HasColumnType("INTEGER");

                    b.ToTable("Apartamentos", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Casa", b =>
                {
                    b.HasBaseType("LogicaNegocio.Entidades.Inmueble");

                    b.Property<bool>("Balcon")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Banios")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Barbacoa")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Dormitorios")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Garage")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Patio")
                        .HasColumnType("INTEGER");

                    b.ToTable("Casas", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Inmueble", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Propietario", "Propietario")
                        .WithMany("Inmuebles")
                        .HasForeignKey("PropietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Apartamento", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Inmueble", null)
                        .WithOne()
                        .HasForeignKey("LogicaNegocio.Entidades.Apartamento", "InmuebleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Casa", b =>
                {
                    b.HasOne("LogicaNegocio.Entidades.Inmueble", null)
                        .WithOne()
                        .HasForeignKey("LogicaNegocio.Entidades.Casa", "InmuebleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Entidades.Propietario", b =>
                {
                    b.Navigation("Inmuebles");
                });
#pragma warning restore 612, 618
        }
    }
}
