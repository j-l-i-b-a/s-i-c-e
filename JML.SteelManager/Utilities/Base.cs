using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JML.SteelIce.Models;

namespace JML.SteelIce.Utilities
{
    public class Base
    {
        //return owner
        public static UserAccount GetBusinessOwner(ApplicationDbContext db)
        {
            UserAccount owner = null;
            var ua = GetAccount(db);

            if (ua.User_Id != ua.Owner)
                owner = db.UserAccount.Where(t => t.User_Id == ua.Owner).FirstOrDefault();
            else
                owner = ua;

            return owner;
        }

        //returns user account
        //public static UserAccount GetUserAccount()
        //{
        //    return GetAccount();
        //}


        private static UserAccount GetAccount(ApplicationDbContext db)
        {
            var _usrid = new Guid(db.Users.Where(t => t.UserName == HttpContext.Current.User.Identity.Name).Select(t => t.Id).FirstOrDefault());

            return db.UserAccount.Where(d => d.User_Id == _usrid).FirstOrDefault();
        }
    }
}