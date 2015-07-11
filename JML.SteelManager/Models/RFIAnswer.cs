using System;
using System.ComponentModel.DataAnnotations;

namespace JML.SteelIce.Models
{
    public class RFIAnswer
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public Guid AnsweredBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Message { get; set; }

        public RFI Rfi { get; set; }
    }
}