using EventsMng.Application.Services;
using EventsMng.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using EventsMng.Application.Contracts.Services;
using EventsMng.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=EventsMng.db"));

// Repositorios (capa de infraestructura)
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
builder.Services.AddScoped<ICertificadoRepository, CertificadoRepository>();
builder.Services.AddScoped<IListaEsperaRepository, ListaEsperaRepository>();
builder.Services.AddScoped<IInscripcionRepository, InscripcionRepository>();

// Servicios de aplicación (capa de lógica de negocio)
builder.Services.AddScoped<IEventoServiceApp, EventoServiceApp>();
builder.Services.AddScoped<IParticipanteServiceApp, ParticipanteServiceApp>();
builder.Services.AddScoped<ICertificadoServiceApp, CertificadoServiceApp>();
builder.Services.AddScoped<IListaEsperaServiceApp, ListaEsperaServiceApp>();
builder.Services.AddScoped<IInscripcionServiceApp, InscripcionServiceApp>();

// API y utilidades
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inicialización de base de datos (opcional)
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedData.Initialize(dbContext);
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

