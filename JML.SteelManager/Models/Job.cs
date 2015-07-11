using System;
using System.ComponentModel.DataAnnotations;

namespace JML.SteelIce.Models
{
    public class Job
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? Deadline { get; set; }

        public double EstimatedValue { get; set; }

        public Project Project { get; set; }
    }
}