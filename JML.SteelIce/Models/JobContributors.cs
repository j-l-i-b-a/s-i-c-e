using System;
using System.ComponentModel.DataAnnotations;

namespace JML.SteelIce.Models
{
    public class JobContributors
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public bool Accepted { get; set; }

        public UserAccount UserAccount { get; set; }

        public Job Job { get; set; }
    }
}