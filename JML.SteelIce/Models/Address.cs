using System;
using System.ComponentModel.DataAnnotations;

namespace JML.SteelIce.Models
{
    public class Address
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public int Name { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string StateProvinceCounty { get; set; }

        public string Country { get; set; }

        public DateTime CreatedDate { get; set; }

        public UserAccount UserAccount { get; set; }

        public Project Project { get; set; }

        public Job Job { get; set; }
    }
}