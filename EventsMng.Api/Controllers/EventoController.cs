using EventsMng.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventsMng.Infrastructure.Persistence;
using EventsMng.Application.Contracts.Services;

namespace EventsMng.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventoServiceApp _eventoService;
        

        public EventoController(ApplicationDbContext context, IEventoServiceApp eventoService)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
            _eventoService = eventoService;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            return await _context.Eventos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(Guid id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
                return NotFound();
            return evento;
        }

        [HttpPost]
        public async Task<ActionResult<Evento>> CreateEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvento), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvento(Guid id, Evento evento)
        {
            if (id != evento.Id)
                return BadRequest();

            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(Guid id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
                return NotFound();

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("{eventoId}/liberar-cupo/{inscripcionId}")]
        public async Task<IActionResult> LiberarCupo(Guid eventoId, Guid inscripcionId)
        {
            try
            {
                await _eventoService.LiberarCupoAsync(eventoId, inscripcionId);
                return Ok(new { mensaje = "Cupo liberado correctamente." });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}

