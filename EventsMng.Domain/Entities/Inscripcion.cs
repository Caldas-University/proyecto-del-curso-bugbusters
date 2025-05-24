using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Entities
{
    public class Inscripcion
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid EventoId { get; set; }

        public Guid ParticipanteId { get; set; }

        public DateTime FechaInscripcion { get; set; } = DateTime.UtcNow;

        public InscripcionEstado Estado { get; set; } = InscripcionEstado.Confirmada;

        public Participante? Participante { get; set; }

        public Evento? Evento { get; set; }
        public void Cancelar()
        {
            Estado = InscripcionEstado.Cancelada;
        }

    }

    public enum InscripcionEstado
    {
        Confirmada,
        Cancelada,
        Asistio
    }
}
