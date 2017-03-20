using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CityGoodTaste.BusinessLayer;
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

            List<string> cultures = new List<string>() { "en-GB", "ru-RU", "uk-UA" };
            if (!cultures.Contains(lang))
            {
                lang = "en-GB";
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

        public static string getCulture()
        {
            return Thread.CurrentThread.CurrentCulture.ThreeLetterWindowsLanguageName;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            List<Restaurant> Restaurants = manager.GetListRestaurants();
            if(Restaurants.Count>8)
            {
                Restaurants.RemoveRange(8, Restaurants.Count - 7);
            }
            return View(Restaurants);
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

        [HttpPost]
        [AjaxOnly]
        public ActionResult GetSearch(string searchTerm)
        {
            List<Restaurant> restaurants;
            using (GoodTasteContext context = new GoodTasteContext())
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    restaurants = context.Restaurants.ToList();
                }
                else
                {
                    restaurants = context.Restaurants.Where(r => r.Name.StartsWith(searchTerm)).ToList();
                }
            }

            return View("~/Views/Restaurant/Details.cshtml", restaurants);
        }

        public JsonResult GetSearchData(string term)
        {
            List<string> restaurantNames;
            using (GoodTasteContext context = new GoodTasteContext())
            {
                restaurantNames = context.Restaurants.Where(r => r.Name.Contains(term)).Select(r => r.Name).ToList();
            }
            return Json(restaurantNames, JsonRequestBehavior.AllowGet);
        }
    }
}