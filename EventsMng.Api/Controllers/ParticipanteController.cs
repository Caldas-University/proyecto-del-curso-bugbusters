using Microsoft.EntityFrameworkCore;
using EventsMng.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EventsMng.Infrastructure.Persistence;

[ApiController]
[Route("api/[controller]")]
public class ParticipanteController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ParticipanteController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Participante>> GetAll() =>
        await _context.Participantes.ToListAsync();

    [HttpPost]
    public async Task<IActionResult> Create(Participante participante)
    {
        _context.Participantes.Add(participante);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = participante.Id }, participante);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Participante>> GetById(Guid id)
    {
        var item = await _context.Participantes.FindAsync(id);
        if (item == null)
            return NotFound();
        return item;
    }
}

