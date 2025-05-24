using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Entities
{
    public class Evento
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int CupoMaximo { get; set; }

        public bool OfreceCertificado { get; set; }

        // Un evento puede tener varios certificados
        public ICollection<Certificado>? Certificados { get; set; }

        public ICollection<Inscripcion>? Inscripciones { get; set; }

        public void LiberarCupoPorCancelacion(Inscripcion inscripcion)
        {
            if (Inscripciones != null && Inscripciones.Contains(inscripcion))
            {
                inscripcion.Cancelar(); // Este método debe estar en Inscripcion
                                        // No hace falta modificar CuposDisponibles porque se calcula automáticamente
            }
        }
        public int CuposDisponibles => CupoMaximo - (Inscripciones?.Count(i => i.Estado == InscripcionEstado.Confirmada) ?? 0);

        public void CancelarInscripcion(Guid inscripcionId)
        {
            var inscripcion = Inscripciones?.FirstOrDefault(i => i.Id == inscripcionId);

            if (inscripcion == null)
                throw new InvalidOperationException("Inscripción no encontrada");

            inscripcion.Cancelar();
        }

    }
}