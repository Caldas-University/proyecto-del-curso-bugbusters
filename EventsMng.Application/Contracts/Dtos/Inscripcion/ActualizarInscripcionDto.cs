using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Application.Contracts.Dtos.Inscripcion
{
    public class ActualizarInscripcionDto
    {
        public Guid? ParticipanteId { get; set; }
        public int? Estado { get; set; } // Se castea luego a InscripcionEstado
        public Guid? EventoId { get; set; }
    }
}
