using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class cambiosInmueble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnioConstruccion",
                table: "Inmuebles");

            migrationBuilder.DropColumn(
                name: "Banios",
                table: "Inmuebles");

            migrationBuilder.DropColumn(
                name: "Barbacoa",
                table: "Inmuebles");

            migrationBuilder.DropColumn(
                name: "M2Edificacods",
                table: "Inmuebles");

            migrationBuilder.DropColumn(
                name: "Plantas",
                table: "Inmuebles");

            migrationBuilder.DropColumn(
                name: "Porteria",
                table: "Inmuebles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnioConstruccion",
                table: "Inmuebles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Banios",
                table: "Inmuebles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Barbacoa",
                table: "Inmuebles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "M2Edificacods",
                table: "Inmuebles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Plantas",
                table: "Inmuebles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Porteria",
                table: "Inmuebles",
                type: "INTEGER",
                nullable: true);
        }
    }
}
