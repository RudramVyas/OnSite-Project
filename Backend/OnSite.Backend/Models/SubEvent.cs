using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnSite.Backend.Models
{
    public class SubEvent
    {
        [Key]
        public int SubEventId { get; set; }

        // Foreign key linking back to the main event
        [ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation property
        public Event Event { get; set; }
    }
}
