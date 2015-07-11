using System;
using System.ComponentModel.DataAnnotations;
using JML.Common;

namespace JML.SteelIce.Models
{
    public class ProjectRole
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public Enumerators.eProjectRole Role { get; set; }

        public UserAccount UserAccount { get; set; }

        public Project Project { get; set; }
    }
}