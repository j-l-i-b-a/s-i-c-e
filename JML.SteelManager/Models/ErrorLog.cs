using System;
using System.ComponentModel.DataAnnotations;

namespace JML.SteelIce.Models
{
    public class ErrorLog
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int? Count { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? RepeatingAt { get; set; }

        public string ExceptionMessage { get; set; }

        public string UserAccount { get; set; }

        public string RepeatLog { get; set; }
    }
}