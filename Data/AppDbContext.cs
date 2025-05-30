using Microsoft.EntityFrameworkCore;
using TurneroApi.Models;

namespace TurneroApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Turno> Turnos { get; set; }
    }
}
