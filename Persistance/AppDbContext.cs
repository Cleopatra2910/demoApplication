using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Cerere> Cereri { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
