using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnSite.Backend.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string Location { get; set; }

        public string QuoteDetails { get; set; }

        // One-to-many: An event can have many sub-events.
        [JsonIgnore] // Avoid cycles during JSON serialization.
        public virtual ICollection<SubEvent> SubEvents { get; set; } = new List<SubEvent>();
    }
}
