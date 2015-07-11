using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JML.SteelIce.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace JML.SteelIce.Utilities
{
    public static class ErrorHandler
    {
        private static ApplicationDbContext _db = new ApplicationDbContext();

        public static bool LogError(Exception ex, ApplicationUser user)
        {
            return LogError(ex, user.Id);
        }

        public static bool LogError(Exception ex, string user)
        {
            try
            {
                var error = new ErrorLog
                {
                    CreatedDate = DateTime.UtcNow,
                    ExceptionMessage = ex.Message,
                    UserAccount = user
                };

                _db.ErrorLog.Add(error);
                _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LogError()
        {
            return true;
        }
    }
}