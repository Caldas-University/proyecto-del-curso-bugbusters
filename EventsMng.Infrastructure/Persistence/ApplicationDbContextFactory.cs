using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EventsMng.Infrastructure.Persistence
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Asegúrate que esta cadena de conexión coincida con la usada en tu Program.cs
            optionsBuilder.UseSqlite("Data Source=events.sqlite");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
