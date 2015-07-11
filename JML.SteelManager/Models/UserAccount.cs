using System;
using System.ComponentModel.DataAnnotations;
using JML.Common;

namespace JML.SteelIce.Models
{
    public class UserAccount
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsEmployee { get; set; }

        public bool NotifyMeAboutActivity { get; set; }

        public byte[] Photo { get; set; }

        public string CompanyName { get; set; }

        public Enumerators.eCompanyType CompanyType { get; set; }

        public DateTime? Established { get; set; }

        public string EstablishedBy { get; set; }

        public bool ManageEmployees { get; set; }

        public bool ManageProjects { get; set; }

        public bool ManageCompany { get; set; }

        public bool IsActive { get; set; }

        public Guid? Owner { get; set; }

        public Guid User_Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}