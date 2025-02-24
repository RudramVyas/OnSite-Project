using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnSite.Backend.Models
{
    public class Supervisor
    {
        [Key]
        public int SupervisorId { get; set; }

        [Required]
        public string Name { get; set; }

        // Level: 2 = L2 supervisor (for events); 1 = L1 supervisor (for sub-events)
        [Required]
        public int Level { get; set; }

        // Navigation property for assignments.
        [JsonIgnore] // Avoid cyclic references.
        public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
