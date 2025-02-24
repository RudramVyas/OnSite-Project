using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace OnSite.Backend.Models
{
    public class TimeSheet
    {
        [Key]
        public int TimeSheetId { get; set; }

        [Required]
        public int AssignmentId { get; set; }

        // Ignore this navigation property during JSON binding/validation
        [JsonIgnore]
        [ValidateNever]
        [ForeignKey("AssignmentId")]
        public virtual Assignment Assignment { get; set; }

        [Required]
        public decimal HoursWorked { get; set; }

        [Required]
        public DateTime WorkDate { get; set; }
    }
}
