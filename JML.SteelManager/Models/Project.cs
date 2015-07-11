using System;
using System.ComponentModel.DataAnnotations;

namespace JML.SteelIce.Models
{
    public class Project
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? Deadline { get; set; }

        public double EstimatedValue { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}