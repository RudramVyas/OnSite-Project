using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnSite.Backend.Models
{
    public class TimeSheet
    {
        [Key]
        public int TimeSheetId { get; set; }

        [ForeignKey("Assignment")]
        public int AssignmentId { get; set; }

        // Hours worked with precision: up to 999.99 hours, adjust as needed.
        public decimal HoursWorked { get; set; }

        public DateTime WorkDate { get; set; }

        // Navigation property
        public Assignment Assignment { get; set; }
    }
}
