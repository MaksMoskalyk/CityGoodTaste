using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityGoodTaste.CustomFilters;
using CityGoodTaste.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CityGoodTaste.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;

            List<string> cultures = new List<string>() { "en-US", "ru-RU", "uk-UA" };
            if (!cultures.Contains(lang))
            {
                lang = "en-US";
            }
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;
            else
            {
                cookie = new HttpCookie("lang");
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
        public ActionResult Index()
        {
            //Initializer init = new Initializer();
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult LogIn()
        {
            ViewBag.Message = "LogIn";
            ApplicationUser user = new ApplicationUser();

            return PartialView("~/Views/Home/Authentication/_LogInModal.cshtml", user);
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult SignUp()
        {
            ViewBag.Message = "SignUp";
            ApplicationUser user = new ApplicationUser();

            return PartialView("~/Views/Home/Authentication/_SignUpModal.cshtml", user);
        }
    }
}