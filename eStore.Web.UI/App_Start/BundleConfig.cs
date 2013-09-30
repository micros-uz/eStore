using System.Web.Optimization;

namespace eStore.Web.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/lib/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/lib/jquery.unobtrusive*",
                "~/Scripts/lib/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout")
                .Include("~/Scripts/lib/jQuery.tmpl.js",
                "~/Scripts/lib/knockout-{version}.debug.js",
                "~/Scripts/lib/knockout.mapping-latest.debug.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/lib/modernizr")
                .Include("~/Scripts/lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/eStore")
                .Include("~/Scripts/app/eStore*"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/social")
                .Include("~/Content/social-buttons.css",
                         "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css")
                .Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}