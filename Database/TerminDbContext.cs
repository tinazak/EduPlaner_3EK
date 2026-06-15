using HAK_BlazorPicoTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace HAK_BlazorPicoTemplate.Database
{
    public class TerminDbContext : DbContext
    {
        public TerminDbContext(DbContextOptions<TerminDbContext> options) : base(options) { }

        // Definiere die Models die EF-Core verwenden soll
        public DbSet<Termin> Termin {  get; set; }
    }
}
