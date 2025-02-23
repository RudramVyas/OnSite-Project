using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnSite.Backend.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        // This assignment must be linked to an Event
        [ForeignKey("Event")]
        public int EventId { get; set; }

        // Optional: May link to a SubEvent (for L1 assignments)
        [ForeignKey("SubEvent")]
        public int? SubEventId { get; set; }

        // Optional: For supervisor assignment
        [ForeignKey("Supervisor")]
        public int? SupervisorId { get; set; }

        // Optional: For laborer assignment
        [ForeignKey("Laborer")]
        public int? LaborerId { get; set; }

        // Role description: e.g., "L2 Supervisor", "L1 Supervisor", "Laborer"
        [Required]
        [MaxLength(20)]
        public string AssignedRole { get; set; }

        // Navigation properties
        public Event Event { get; set; }
        public SubEvent SubEvent { get; set; }
        public Supervisor Supervisor { get; set; }
        public Laborer Laborer { get; set; }

        // Optional: Navigation property for timesheets associated with this assignment
        public ICollection<TimeSheet> TimeSheets { get; set; }
    }
}
