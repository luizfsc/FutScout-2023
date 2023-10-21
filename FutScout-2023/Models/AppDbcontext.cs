using Microsoft.EntityFrameworkCore;

namespace FutScout_2023.Models
{
    public class AppDbcontext : DbContext
    {
            public AppDbcontext(DbContextOptions<AppDbcontext> options ) : base(options) { }

        public DbSet<Atacante> Atacantes { get; set; }
    }
}
