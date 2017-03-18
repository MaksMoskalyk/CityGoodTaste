using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CityGoodTaste.CustomFilters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureName = null;
            HttpCookie cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = "en-GB";

            List<string> cultures = new List<string>() { "en-GB", "ru-RU", "uk-UA" };
            if (!cultures.Contains(cultureName))
            {
                cultureName = "en-GB";
            }
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName); // de-DE
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureName);
        }
    }
}