using System;
using System.ComponentModel.DataAnnotations;
using JML.Common;

namespace JML.SteelIce.Models
{
    public class JobPermissions
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public Enumerators.eJobPermissions Permissions { get; set; }

        public Job Job { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}