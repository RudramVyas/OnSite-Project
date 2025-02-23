using System.ComponentModel.DataAnnotations;

namespace OnSite.Backend.Models
{
    public class Laborer
    {
        [Key]
        public int LaborerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Optional: Navigation property for assignments
        public ICollection<Assignment> Assignments { get; set; }
    }
}
