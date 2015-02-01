using System;
using System.ComponentModel.DataAnnotations;

namespace JML.SteelIce.Models
{
    public class JobTask
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public Guid Responsible { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? Deadline { get; set; }

        public Job Job { get; set; }
    }
}