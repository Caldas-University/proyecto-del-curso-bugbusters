using EventsMng.Domain.Entities;
using EventsMng.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Infrastructure.Repositories
{
    public class ListaEsperaRepository : IListaEsperaRepository
    {
        private readonly ApplicationDbContext _context;
        public async Task AgregarAsync(Guid eventoId, Guid participanteId)
        {
            _context.ListasEspera.Add(new ListaEspera
            {
                EventoId = eventoId,
                ParticipanteId = participanteId,
                FechaRegistro = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }

        public async Task<List<ListaEspera>> ObtenerPorEventoAsync(Guid eventoId)
        {
            return await _context.ListasEspera
            .Where(le => le.EventoId == eventoId)
            .OrderBy(le => le.FechaRegistro)
    .       ToListAsync();
        }

        public async Task<bool> YaEstaEnLista(Guid eventoId, Guid participanteId)
        {
            return await _context.ListasEspera
                .AnyAsync(le => le.EventoId == eventoId && le.ParticipanteId == participanteId);
        }
    }
}
