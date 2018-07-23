using System.Web.Optimization;

namespace Planet.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Assets/client/js/jquery.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Assets/client/js/jquery.validate.min.js",
                "~/Assets/client/js/jquery.validate.unobtrusive.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Assets/client/vendor/jquery-ui-1.12.1/jquery-ui.min.js",
                "~/Assets/client/js/tether.min.js",
                "~/Assets/client/js/bootstrap.min.js",
                "~/Assets/client/js/bootstrap-hover-dropdown.min.js",
                "~/Assets/client/js/owl.carousel.min.js",
                "~/Assets/client/js/echo.min.js",
                "~/Assets/client/js/wow.min.js",
                "~/Assets/client/js/jquery.easing.min.js",
                "~/Assets/client/js/jquery.waypoints.min.js",
                "~/Assets/client/vendor/numeral/numeral.js",
                "~/Assets/client/js/electro.js",
                "~/Assets/client/vendor/toast/toastr.min.js",
                "~/Assets/client/js/custom.js",
                "~/Assets/client/js/controller/commonController.js"
            ));


            BundleTable.EnableOptimizations = true;
        }
    }
}
