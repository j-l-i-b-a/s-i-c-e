using System;
using System.ComponentModel.DataAnnotations;
using JML.Common;

namespace JML.SteelIce.Models
{
    public class Invitation
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public Guid Inviter { get; set; }

        public Enumerators.eInvitationStatus InvitationStatus { get; set; }

        [EmailAddress]
        [Required]
        public string Invitee { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModified { get; set; }

        public string InvitionToJob { get; set; }
    }
}