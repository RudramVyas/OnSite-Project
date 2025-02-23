using System.ComponentModel.DataAnnotations;

namespace OnSite.Backend.Models
{
    public class Supervisor
    {
        [Key]
        public int SupervisorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Level 2 = Event-level, Level 1 = Sub-event level
        public int Level { get; set; }

        // Optional: Navigation property for assignments
        public ICollection<Assignment> Assignments { get; set; }
    }
}
