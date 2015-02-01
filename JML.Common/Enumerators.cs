namespace JML.Common
{
    public class Enumerators
    {
        public enum eCompanyType
        {
            Inc,
            Ltd,
            LLC,
            Sro
        }

        public enum eProjectRole
        {
            NotSet = 0,
            Architect = 1,
            StructuralEngineer = 2,
            Detailer = 3,
            Contractor = 4,
            Supplier = 5
        }

        public enum eAddress
        {
            NotSet = 0,
            Home = 1,
            Billing = 2,
            Delivery = 3
        }

        public enum eJobPermissions
        {
            NotSet = 0,
            Read = 1,
            Write = 2,
            Full = 3,
            Extended = 4
        }

        public enum eRFIStatus 
        { 
            NotSet = 0,
            Open = 1,
            Closed = 2,
            Reopen = 3
        }

        public enum eInvitationStatus 
        { 
            NotSet = 0,
            Invited = 1,
            Accepted = 2,
            Declined = 3
        }
    }
}