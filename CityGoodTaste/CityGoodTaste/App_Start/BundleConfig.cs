using System.Web;
using System.Web.Optimization;

namespace CityGoodTaste
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Script
            //Default
            bundles.Add(new ScriptBundle("~/bundles/defaultScript").Include(
                      "~/Scripts/Default/jQuery/jquery-{version}.js",
                      "~/Scripts/Default/jQuery/jquery.validate*",
                      "~/Scripts/Default/jQuery/jquery.bootstrap-touchspin.js",
                      "~/Scripts/Default/jQuery/jquery.unobtrusive-ajax.js",
                      "~/Scripts/Default/jQuery/jquery-ui-{version}.js",
                      "~/Scripts/Default/Angular/angular.js",
                      "~/Scripts/Default/modernizr-*",
                      "~/Scripts/Default/bootstrap.js",                      
                      "~/Scripts/Default/clockpicker.js",
                      "~/Scripts/Default/datetimepicker.js",
                      "~/Scripts/Default/respond.js",
                      "~/Scripts/Default/moment-with-locales.min.js"));

            //Custom  
            bundles.Add(new ScriptBundle("~/bundles/customScript").Include(
                     "~/Scripts/Custom/Details.js",
                     "~/Scripts/Custom/Events.js",
                     "~/Scripts/Custom/MainPage.js",
                     "~/Scripts/Custom/Restaurants.js",
                     "~/Scripts/Custom/_Layout.js"));
            #endregion

            #region Style
            //Default
            bundles.Add(new StyleBundle("~/bundles/defaultStyle").Include(
                    "~/Content/css/Default/bootstrap.css",
                    "~/Content/icons/open-iconic/font/css/open-iconic.css",
                    "~/Content/css/Default/bootstrap-datetimepicker.css",
                    "~/Content/css/Default/clockpicker.css",
                    "~/Content/css/Default/jquery.bootstrap-touchspin.css",
                    "~/Content/css/Default/Site.css",
                    "~/Content/css/Default/bootstrap.css",
                    "~/Content/icons/open-iconic/font/css/open-iconic.css",
                    "~/Content/css/Default/bootstrap-datetimepicker.css",
                    "~/Content/css/Default/clockpicker.css",
                    "~/Content/css/Default/jquery.bootstrap-touchspin.css",
                    "~/Content/css/Default/Site.css",
                     "~/Content/css/Default/themes/base/jquery-ui.css"
                     ));

            //Custom          
            bundles.Add(new StyleBundle("~/bundles/customStyle").Include(
                    "~/Content/css/Custom/Restaurants.css",
                    "~/Content/css/Custom/AuthenticationModals.css",
                    "~/Content/css/Custom/AuthenticationPages.css",
                    "~/Content/css/Custom/ModalFix.css",
                    "~/Content/css/Custom/MainPage.css",
                    "~/Content/css/Custom/CheckboxesAndRadios.css",
                    "~/Content/css/Custom/Layout.css"
                    ));
            #endregion
        }
    }
}