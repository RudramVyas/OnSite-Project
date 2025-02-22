using System.Collections.Generic;
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
    }
}
