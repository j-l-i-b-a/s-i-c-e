using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace JML.SteelIce
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/steelice.js",
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js",
            "~/Scripts/jquery-ui.unobtrusive-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/_run.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/jquery.ui.min.css",
                "~/Content/themes/base/jquery.ui.structure.min.css",
                "~/Content/themes/base/jquery.ui.theme.min.css",
                "~/Content/themes/base/all.css",
                "~/Content/themes/base/datetimepicker.css"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.min.css",
                 "~/Content/jquery.datetimepicker.css",
                 "~/Content/Site.css"));
        }
    }
}
