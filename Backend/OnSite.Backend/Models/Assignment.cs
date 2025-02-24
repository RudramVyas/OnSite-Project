using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace OnSite.Backend.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        // Only the foreign key IDs are used for input
        public int? EventId { get; set; }
        public int? SubEventId { get; set; }
        public int? SupervisorId { get; set; }
        public int? LaborerId { get; set; }

        [Required]
        public string AssignedRole { get; set; }

        // Navigation properties (ignored during JSON input and validation)
        [JsonIgnore]
        [ValidateNever]
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        [JsonIgnore]
        [ValidateNever]
        [ForeignKey("SubEventId")]
        public virtual SubEvent SubEvent { get; set; }

        [JsonIgnore]
        [ValidateNever]
        [ForeignKey("SupervisorId")]
        public virtual Supervisor Supervisor { get; set; }

        [JsonIgnore]
        [ValidateNever]
        [ForeignKey("LaborerId")]
        public virtual Laborer Laborer { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public virtual ICollection<TimeSheet> TimeSheets { get; set; } = new List<TimeSheet>();
    }
}
