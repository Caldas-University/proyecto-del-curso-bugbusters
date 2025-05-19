using FlightReservation.Application.Services;
using FlightReservation.Infrastructure.Persistence;
using FlightReservation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FlightReservation.Application.Contracts.Services;
using FlightReservation.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=flightreservation.db"));

builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
builder.Services.AddScoped<ICertificadoRepository, CertificadoRepository>();
builder.Services.AddScoped<IListaEsperaRepository, ListaEsperaRepository>();
builder.Services.AddScoped<IInscripcionRepository, InscripcionRepository>();


// aqui se asocia la interfaz con la logica
builder.Services.AddScoped<IEventoServiceApp, EventoServiceApp>();
builder.Services.AddScoped<IParticipanteServiceApp, ParticipanteServiceApp>();
builder.Services.AddScoped<ICertificadoServiceApp, CertificadoServiceApp>();
builder.Services.AddScoped<IListaEsperaServiceApp, ListaEsperaServiceApp>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
