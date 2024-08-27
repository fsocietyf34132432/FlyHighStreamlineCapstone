using Microsoft.EntityFrameworkCore;

namespace FlyHighStreamlineCapstone.Data
{
    public class FlyHighStreamlineCapstoneContext : DbContext
    {
        public FlyHighStreamlineCapstoneContext (DbContextOptions<FlyHighStreamlineCapstoneContext> options)
            : base(options)
        {
        }

        public DbSet<FlyHighStreamlineCapstone.Models.Airline> Airline { get; set; } = default!;
        public DbSet<FlyHighStreamlineCapstone.Models.Aircraft> Aircraft { get; set; } = default!;
    }
}
