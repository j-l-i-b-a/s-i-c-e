using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using JML.SteelIce.Models;
using Microsoft.AspNet.Identity;

namespace JML.SteelIce
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError().GetBaseException();
            Server.ClearError();

            var a = Utilities.ErrorHandler.LogError(ex, HttpContext.Current.User.Identity.GetUserId() ?? string.Empty);
        }
    }
}
