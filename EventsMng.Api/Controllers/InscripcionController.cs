﻿using Microsoft.EntityFrameworkCore;
using EventsMng.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EventsMng.Infrastructure.Persistence;
using EventsMng.Application.Contracts.Services;
using EventsMng.Application.Contracts.Dtos.Inscripcion;

[ApiController]
[Route("api/[controller]")]
public class InscripcionController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IInscripcionServiceApp _inscripcionService;

    public InscripcionController(ApplicationDbContext context, IInscripcionServiceApp inscripcionService)
    {
        _context = context;
        _inscripcionService = inscripcionService;
    }

    [HttpPost]
    public async Task<IActionResult> Inscribirse(Guid eventoId, Guid participanteId)
    {
        var cupoOcupado = await _context.Inscripciones.CountAsync(i => i.EventoId == eventoId && i.Estado == InscripcionEstado.Confirmada);
        var cupoMaximo = (await _context.Eventos.FindAsync(eventoId))?.CupoMaximo ?? 0;

        if (cupoOcupado < cupoMaximo) {
            var inscripcion = new Inscripcion
            {
                EventoId = eventoId,
                ParticipanteId = participanteId,
                Estado = cupoOcupado < cupoMaximo ? InscripcionEstado.Confirmada : InscripcionEstado.Cancelada
            };

            _context.Inscripciones.Add(inscripcion);
        } else
        {
            var listaEspera = new ListaEspera
            {
                EventoId = eventoId,
                ParticipanteId = participanteId
            };

            _context.ListasEspera.Add(listaEspera);
        }
        

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetInscripciones()
    {
        var inscripciones = await _inscripcionService.ObtenerInscripcionesAsync();
        return Ok(inscripciones);
    }

    [HttpGet("{eventoId}/participantes")]
    public async Task<IEnumerable<Inscripcion>> GetParticipantesPorEvento(Guid eventoId)
    {
        return await _context.Inscripciones
            .Where(i => i.EventoId == eventoId)
            .Include(i => i.Participante)
            .ToListAsync();
    }

    [HttpGet("historial/{participanteId}")]
    public async Task<IActionResult> GetHistorialPorParticipante(Guid participanteId)
    {
        var historial = await _inscripcionService.ObtenerHistorialPorParticipanteAsync(participanteId);
        return Ok(historial);
    }

    [HttpPut("{inscripcionId}")]
    public async Task<IActionResult> ActualizarInscripcion(Guid inscripcionId, [FromBody] ActualizarInscripcionDto dto)
    {
        var actualizado = await _inscripcionService.ActualizarInscripcionAsync(inscripcionId, dto);
        if (!actualizado)
            return NotFound();

        return NoContent();
    }

    [HttpPut("{inscripcionId}/cancelar")]
    public async Task<IActionResult> CancelarInscripcion(Guid inscripcionId, [FromQuery] Guid participanteId)
    {
        var inscripcion = await _context.Inscripciones.FindAsync(inscripcionId);
        if (inscripcion == null || inscripcion.ParticipanteId != participanteId || inscripcion.Estado != InscripcionEstado.Confirmada)
            return BadRequest("No se pudo cancelar la inscripción (verifica que aún se puede cancelar y que la inscripción pertenece al participante).");

        inscripcion.Estado = InscripcionEstado.Cancelada;
        await _context.SaveChangesAsync();

        var eventoId = inscripcion.EventoId;

        var primerEnLista = await _context.ListasEspera
            .Where(le => le.EventoId == eventoId)
            .OrderBy(le => le.Posicion)
            .FirstOrDefaultAsync();

        if (primerEnLista != null)
        {
            var nuevaInscripcion = new Inscripcion
            {
                EventoId = eventoId,
                ParticipanteId = primerEnLista.ParticipanteId,
                Estado = InscripcionEstado.Confirmada
            };

            _context.Inscripciones.Add(nuevaInscripcion);

            _context.ListasEspera.Remove(primerEnLista);

            await _context.SaveChangesAsync();
        }

        return NoContent();
    }

}

