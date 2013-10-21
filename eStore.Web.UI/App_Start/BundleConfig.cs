using System.Web.Optimization;

namespace eStore.Web.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Force optimization to be on or off, regardless of web.config setting
            //BundleTable.EnableOptimizations = false;
            bundles.UseCdn = false;

            // .debug.js, -vsdoc.js and .intellisense.js files 
            // are in BundleTable.Bundles.IgnoreList by default.
            // Clear out the list and add back the ones we want to ignore.
            // Don't add back .debug.js.
            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*intellisense.js");

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/lib/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/lib/jquery.unobtrusive*",
                "~/Scripts/lib/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout")
                .Include("~/Scripts/lib/jQuery.tmpl.js",
                "~/Scripts/lib/knockout-{version}.js",
                "~/Scripts/lib/knockout.mapping-latest.js"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap")
            //    .Include("~/Scripts/lib/bootstrap.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/eStore")
                .Include(
                        "~/Scripts/app/eStore.common.js",
                        "~/Scripts/app/eStore.filepick.js",
                        "~/Scripts/app/eStore.dataservice.js",
                        "~/Scripts/app/eStore.startup.js",
                        "~/Scripts/app/eStore.custom.chooseGenre.js",
                        "~/Scripts/app/eStore.filepick.js",
                        "~/Scripts/app/estore.addtocartviewmodel.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/social")
                .Include("~/Content/social-buttons.css",
                         "~/Content/font-awesome.min.css"));
        }
    }
}