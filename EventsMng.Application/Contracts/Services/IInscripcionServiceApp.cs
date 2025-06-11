using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Application.Contracts.Services
{
    public interface IInscripcionServiceApp
    {
        Task InscribirAsync(Guid eventoId, Guid participanteId);

        Task CancelarAsync(Guid eventoId, Guid participanteId);      
        Task RegistrarAsistenciaAsync(Guid eventoId, Guid participanteId);


    }
}
