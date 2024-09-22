using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InmuebleFotos",
                columns: table => new
                {
                    InmuebleFotoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InmuebleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CarpetaPath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmuebleFotos", x => x.InmuebleFotoId);
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    PropietarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmailId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Contrasena = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.PropietarioId);
                });

            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    InmuebleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PropietarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Propuesta = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Departamento = table.Column<int>(type: "INTEGER", nullable: false),
                    Ciudad = table.Column<string>(type: "TEXT", nullable: false),
                    Barrio = table.Column<string>(type: "TEXT", nullable: false),
                    Calle = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroPuerta = table.Column<string>(type: "TEXT", nullable: false),
                    Plantas = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    AnioConstruccion = table.Column<int>(type: "INTEGER", nullable: false),
                    M2Edificacods = table.Column<decimal>(type: "TEXT", nullable: false),
                    M2Totales = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.InmuebleId);
                    table.ForeignKey(
                        name: "FK_Inmuebles_Propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietarios",
                        principalColumn: "PropietarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    InmuebleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Piso = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroApartamento = table.Column<string>(type: "TEXT", nullable: false),
                    Dormitorios = table.Column<int>(type: "INTEGER", nullable: false),
                    Banios = table.Column<int>(type: "INTEGER", nullable: false),
                    Balcon = table.Column<bool>(type: "INTEGER", nullable: false),
                    Garage = table.Column<bool>(type: "INTEGER", nullable: false),
                    Patio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Barbacoa = table.Column<bool>(type: "INTEGER", nullable: false),
                    Porteria = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.InmuebleId);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmuebles",
                        principalColumn: "InmuebleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casas",
                columns: table => new
                {
                    InmuebleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Dormitorios = table.Column<int>(type: "INTEGER", nullable: false),
                    Banios = table.Column<int>(type: "INTEGER", nullable: false),
                    Balcon = table.Column<bool>(type: "INTEGER", nullable: false),
                    Garage = table.Column<bool>(type: "INTEGER", nullable: false),
                    Patio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Barbacoa = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casas", x => x.InmuebleId);
                    table.ForeignKey(
                        name: "FK_Casas_Inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmuebles",
                        principalColumn: "InmuebleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_PropietarioId",
                table: "Inmuebles",
                column: "PropietarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Casas");

            migrationBuilder.DropTable(
                name: "InmuebleFotos");

            migrationBuilder.DropTable(
                name: "Inmuebles");

            migrationBuilder.DropTable(
                name: "Propietarios");
        }
    }
}
