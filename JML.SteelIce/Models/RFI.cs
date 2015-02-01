using System;
using System.ComponentModel.DataAnnotations;
using JML.Common;

namespace JML.SteelIce.Models
{
    public class RFI
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Enumerators.eProjectRole Addressee { get; set; }

        public Enumerators.eRFIStatus Status { get; set; }

        public Guid StatusChangeBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? Deadline { get; set; }

        public Job Job { get; set; }
    }
}