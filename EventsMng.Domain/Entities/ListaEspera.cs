using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Entities
{
    public class ListaEspera
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid EventoId { get; set; }

        public Guid ParticipanteId { get; set; }

        public int Posicion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        public DateTime? VenceEn { get; set; }

        public Evento? Evento { get; set; }
    }
}
