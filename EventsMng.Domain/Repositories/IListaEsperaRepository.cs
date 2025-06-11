using EventsMng.Domain.Entities;

namespace EventsMng.Domain.Repositories
{
    public interface IListaEsperaRepository
    {
        Task AgregarAsync(ListaEspera listaEspera);
        Task GuardarCambiosAsync();
    }
}
