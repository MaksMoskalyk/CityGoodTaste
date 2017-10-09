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

                      "~/Scripts/Default/modernizr-*",
                      "~/Scripts/Default/bootstrap.js",                      
                      "~/Scripts/Default/respond.js",
                      "~/Scripts/Default/moment-with-locales.min.js"));

            //Custom  
            bundles.Add(new ScriptBundle("~/bundles/customScript").Include(
                     "~/Scripts/Custom/_Layout.js"));
            #endregion

            #region Style
            //Default
            bundles.Add(new StyleBundle("~/bundles/defaultStyle").Include(
                    "~/Content/css/Default/bootstrap.css",                    
                    "~/Content/css/Default/jquery.bootstrap-touchspin.css",
                    "~/Content/css/Default/Site.css",
                    "~/Content/css/Default/themes/base/jquery-ui.css",

                    "~/Content/icons/open-iconic/font/css/open-iconic.css"));

            //Custom          
            bundles.Add(new StyleBundle("~/bundles/customStyle").Include(
                    "~/Content/css/Custom/Account/AuthenticationPages.css",
                    "~/Content/css/Custom/Account/ManageAccount.css",

                    "~/Content/css/Custom/Controls/CheckboxesAndRadios.css",
                    "~/Content/css/Custom/Controls/TextboxClearButton.css",

                    "~/Content/css/Custom/ModalDialogs/AuthenticationModals.css",
                    "~/Content/css/Custom/ModalDialogs/ModalFix.css",

                    "~/Content/css/Custom/Layout.css",
                    "~/Content/css/Custom/MainPage.css",                    
                    "~/Content/css/Custom/Restaurants.css"));
            #endregion
        }
    }
}