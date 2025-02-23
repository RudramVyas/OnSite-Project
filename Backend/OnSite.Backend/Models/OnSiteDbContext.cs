using Microsoft.EntityFrameworkCore;

namespace OnSite.Backend.Models
{
    public class OnSiteDbContext : DbContext
    {
        public OnSiteDbContext(DbContextOptions<OnSiteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<SubEvent> SubEvents { get; set; }
        public DbSet<Supervisor> Supervisor { get; set; }
        public DbSet<Laborer> Laborer { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }
    }
}
