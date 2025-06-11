using System;
using EventsMng.Application.Contracts.Services;
using EventsMng.Infrastructure.Repositories;
using EventsMng.Domain.Entities;
using FluentResults;
using System;

namespace EventsMng.Application.Services
{
    public class ListaEsperaServiceApp : IListaEsperaServiceApp
    {
        private readonly IListaEsperaRepository _repository;
        private readonly IEventoRepository _eventoRepo;

        public ListaEsperaServiceApp(IListaEsperaRepository repository, IEventoRepository eventoRepo)
        {
            _repository = repository;
            _eventoRepo = eventoRepo;
        }

        public Task AgregarAsync(Guid eventoId, Guid participanteId)
        {
            throw new NotImplementedException();
        }

        public Task ObtenerPorEventoAsync(Guid eventoId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> InscribirseEnListaDeEspera(Guid eventoId, Guid participanteId)
        {
            var evento = await _eventoRepo.ObtenerPorIdAsync(eventoId);

            if (evento == null || !evento.ListaEsperaHabilitada || evento.CuposDisponibles > 0)
                return Result.Fail("El evento no permite lista de espera o tiene cupos.");

            var yaInscrito = await _repository.YaEstaEnLista(eventoId, participanteId);
            if (yaInscrito)
                return Result.Fail("El participante ya está en la lista de espera.");

            var entrada = new ListaEspera
            {
                Id = Guid.NewGuid(),
                EventoId = eventoId,
                ParticipanteId = participanteId,
                FechaRegistro = DateTime.UtcNow
            };

            await _repository.AgregarAsync(eventoId, participanteId);
            return Result.Ok();
        }
    }

}
