using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MyForum.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundle/css").Include(
                       "~/Content/bootstrap.min.css",
                       "~/Content/bootstrap-theme.min.css",
                       "~/Content/plugins/angular-loading-bar/loading-bar.css",
                       "~/Content/Site.css"
                       ));

            bundles.Add(new ScriptBundle("~/bundle/js").Include(

                         "~/Scripts/jquery-2.1.1.min.js"
                        , "~/Scripts/bootstrap.min.js"
                        , "~/Scripts/angular.min.js"
                        , "~/Scripts/angular-route.min.js"
                        , "~/Scripts/angular-resource.min.js"
                        , "~/Scripts/angular-animate.min.js"
                        , "~/Content/plugins/angular-loading-bar/loading-bar.js"
                        , "~/Content/plugins/noty/packaged/jquery.noty.packaged.min.js"
                        , "~/Scripts/app.init.js"
                        ));


            BundleTable.EnableOptimizations = true;
            bundles.FileSetOrderList.Clear();


        }
    }
}