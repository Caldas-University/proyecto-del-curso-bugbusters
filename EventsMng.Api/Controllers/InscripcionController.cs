﻿using Microsoft.EntityFrameworkCore;
using EventsMng.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EventsMng.Infrastructure.Persistence;

[ApiController]
[Route("api/[controller]")]
public class InscripcionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public InscripcionController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Inscribirse(Guid eventoId, Guid participanteId)
    {
        var cupoOcupado = await _context.Inscripciones.CountAsync(i => i.EventoId == eventoId && i.Estado == InscripcionEstado.Confirmada);
        var cupoMaximo = (await _context.Eventos.FindAsync(eventoId))?.CupoMaximo ?? 0;

        var inscripcion = new Inscripcion
        {
            EventoId = eventoId,
            ParticipanteId = participanteId,
            Estado = cupoOcupado < cupoMaximo ? InscripcionEstado.Confirmada : InscripcionEstado.Cancelada
        };

        _context.Inscripciones.Add(inscripcion);
        await _context.SaveChangesAsync();

        return Ok(inscripcion);
    }

    [HttpGet("{eventoId}/participantes")]
    public async Task<IEnumerable<Inscripcion>> GetParticipantesPorEvento(Guid eventoId)
    {
        return await _context.Inscripciones
            .Where(i => i.EventoId == eventoId)
            .Include(i => i.Participante)
            .ToListAsync();
    }
}

