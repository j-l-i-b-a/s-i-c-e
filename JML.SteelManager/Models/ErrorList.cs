using System;
using System.ComponentModel.DataAnnotations;

namespace JML.SteelIce.Models
{
    public class ErrorList
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string ExceptionMessage { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}