using FlightReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FlightReservation.Infrastructure.Persistence;

[ApiController]
[Route("api/[controller]")]
public class ListaEsperaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ListaEsperaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AgregarListaEspera(Guid eventoId, Guid participanteId)
    {
        var lista = new ListaEspera
        {
            EventoId = eventoId,
            ParticipanteId = participanteId,
            FechaRegistro = DateTime.UtcNow
        };

        _context.ListasEspera.Add(lista);
        await _context.SaveChangesAsync();
        return Ok(lista);
    }
}
