using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.Propietarios;
using LogicaNegocio.IRepositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
builder.Services.AddDbContext<InmuStarsDBContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("InmuStarsDBConnection"));
});

// Repositorios
builder.Services.AddScoped<IRepositorioPropietario, RepositorioPropietario>();

// Servicios
builder.Services.AddScoped<IServiciosPropietario, ServiciosPropietario>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
