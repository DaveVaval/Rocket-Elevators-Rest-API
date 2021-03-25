using Microsoft.EntityFrameworkCore;

namespace Rocket_Elevators_Rest_API.Models
{
    public class InterventionsContext : DbContext
    {
        public InterventionsContext(DbContextOptions<InterventionsContext> options) : base(options)
        {

        }

        public DbSet<Interventions> Interventions { get; set; }
    }
}