using EventsMng.Domain.Entities;

namespace EventsMng.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Asegúrate de que la base de datos esté creada
            context.Database.EnsureCreated();

        }
    }
}
