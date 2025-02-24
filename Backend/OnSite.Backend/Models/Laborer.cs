using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnSite.Backend.Models
{
    public class Laborer
    {
        [Key]
        public int LaborerId { get; set; }

        [Required]
        public string Name { get; set; }

        // Indicates if the laborer is available for assignment.
        public bool IsAvailable { get; set; } = true;

        // Optionally include assignments; mark with [JsonIgnore] to avoid cycles.
        [JsonIgnore]
        public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
