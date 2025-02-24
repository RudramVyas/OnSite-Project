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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Event -> SubEvent relationship: each SubEvent requires an Event.
            modelBuilder.Entity<SubEvent>()
                .HasOne(se => se.Event)
                .WithMany(e => e.SubEvents)
                .HasForeignKey(se => se.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Assignment relationships:

            // For L2 Supervisor assignments, Assignment.EventId is used.
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Event)
                .WithMany() // No navigation property in Event
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.SetNull);

            // For L1 Supervisor or Laborer assignments, Assignment.SubEventId is used.
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.SubEvent)
                .WithMany() // No navigation property in SubEvent
                .HasForeignKey(a => a.SubEventId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent deletion if assignments exist

            // Relationship for Supervisor assignments.
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Supervisor)
                .WithMany(s => s.Assignments)
                .HasForeignKey(a => a.SupervisorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship for Laborer assignments.
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Laborer)
                .WithMany() // Optionally, add a navigation property in Laborer if desired
                .HasForeignKey(a => a.LaborerId)
                .OnDelete(DeleteBehavior.SetNull);

            // Assignment -> TimeSheet: an Assignment can have many TimeSheets.
            modelBuilder.Entity<Assignment>()
                .HasMany(a => a.TimeSheets)
                .WithOne(t => t.Assignment)
                .HasForeignKey(t => t.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
