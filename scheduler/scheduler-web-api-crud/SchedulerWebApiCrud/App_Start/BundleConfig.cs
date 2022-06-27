using System.Web;
using System.Web.Optimization;

namespace SchedulerWebApiCrud
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new ScriptBundle("~/bundles/Kendo/js").Include(
                    "~/Scripts/Kendo/2022.2.621/jquery.min.js",
                    "~/Scripts/Kendo/2022.2.621/kendo.all.min.js",
                    "~/Scripts/Kendo/2022.2.621/kendo.aspnetmvc.min.js"
                ));
           
            bundles.Add(new StyleBundle("~/Kendo/styles").Include("~/Kendo/styles/kendo.common.min.css",
               "~/Kendo/styles/kendo.default.min.css"));
           
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //bundles.IgnoreList.Clear();
        }
    }
}
