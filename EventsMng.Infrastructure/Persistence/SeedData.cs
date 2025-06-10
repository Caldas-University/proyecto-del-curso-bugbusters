using EventsMng.Domain.Entities;

namespace EventsMng.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Aseg�rate de que la base de datos est� creada
            context.Database.EnsureCreated();

        }
    }
}
