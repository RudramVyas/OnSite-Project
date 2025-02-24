using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace OnSite.Backend.Models
{
    public class SubEvent
    {
        [Key]
        public int SubEventId { get; set; }

        [Required]
        public int EventId { get; set; }

        // Remove any [Required] attribute from the navigation property
        [JsonIgnore]
        [ValidateNever] // Tells the model binder to skip validation for this property
        public virtual Event Event { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
