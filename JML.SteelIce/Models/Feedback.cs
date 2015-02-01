using System;
using System.ComponentModel.DataAnnotations;

namespace JML.SteelIce.Models
{
    public class Feedback
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }
    }
}