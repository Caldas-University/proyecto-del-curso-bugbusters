using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;
using EventsMng.Infrastructure.Persistence;

namespace EventsMng.Domain.Repositories
{
    public class ListaEsperaRepository : IListaEsperaRepository
    {
        private readonly ApplicationDbContext _context;

        public ListaEsperaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AgregarAsync(ListaEspera listaEspera)
        {
            _context.ListasEspera.Add(listaEspera);
            await _context.SaveChangesAsync();
        }

        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

