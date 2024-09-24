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
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
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
                    Barrio = table.Column<string>(type: "TEXT", nullable: true),
                    Calle = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroPuerta = table.Column<string>(type: "TEXT", nullable: true),
                    Plantas = table.Column<int>(type: "INTEGER", nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: true),
                    AnioConstruccion = table.Column<int>(type: "INTEGER", nullable: true),
                    M2Edificacods = table.Column<decimal>(type: "TEXT", nullable: true),
                    M2Totales = table.Column<decimal>(type: "TEXT", nullable: true),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Piso = table.Column<int>(type: "INTEGER", nullable: true),
                    NumeroApartamento = table.Column<string>(type: "TEXT", nullable: false),
                    Dormitorios = table.Column<int>(type: "INTEGER", nullable: true),
                    Banios = table.Column<int>(type: "INTEGER", nullable: true),
                    Balcon = table.Column<bool>(type: "INTEGER", nullable: true),
                    Garage = table.Column<bool>(type: "INTEGER", nullable: true),
                    Patio = table.Column<bool>(type: "INTEGER", nullable: true),
                    Barbacoa = table.Column<bool>(type: "INTEGER", nullable: true),
                    Porteria = table.Column<bool>(type: "INTEGER", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_PropietarioId",
                table: "Inmuebles",
                column: "PropietarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InmuebleFotos");

            migrationBuilder.DropTable(
                name: "Inmuebles");

            migrationBuilder.DropTable(
                name: "Propietarios");
        }
    }
}
