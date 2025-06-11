using EventsMng.Domain.Entities;
using EventsMng.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet]
    public async Task<List<ListaEspera>> ObtenerListasEspera()
    {
        return await _context.ListasEspera.ToListAsync();
    }

    [HttpGet("{idEvento}/listasEspera")]
    public async Task<List<ListaEspera>> ObtenerListasEsperaPorIdEvento(Guid idEvento)
    {
        return await _context.ListasEspera.Where(le => le.EventoId == idEvento).ToListAsync();
    }
}
