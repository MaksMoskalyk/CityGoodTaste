using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CityGoodTaste.BusinessLayer;
using CityGoodTaste.CustomFilters;
using CityGoodTaste.Models;
using CityGoodTaste.Models.ViewModels;

namespace CityGoodTaste.Controllers
{
    [Culture]
    public class RestaurantController : Controller
    {

        // GET: Restaurant
        public ActionResult Restaurants(string searchText)
        {
            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            List<Restaurant> Restaurants = manager.GetFoundRestaurants(searchText);
            if (Restaurants.Count > 1)
                return View(Restaurants);
            else
                return View("~/Views/Restaurant/Details.cshtml", Restaurants[0]);
        }

        // POST: Restaurant/Restaurants
        [HttpPost]
        public ActionResult Restaurants(int? id)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Create
        public ActionResult Events()
        {
            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            var RestaurantEvent = manager.GetListRestaurantEvents();
            return View(RestaurantEvent);
        }

        // GET: Restaurant/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            Restaurant Rest =  manager.GetRestaurant(id);
            ViewBag.UserId = manager.GetCurrectUserId();
            if (Rest == null)
            {
                return HttpNotFound();
            }
            return View(Rest);

        }

        public ActionResult _ReservedTablesPartial(Models.ViewModels.RestaurantShemaViewModel model)
        {
            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            manager.ReservTables(model.Tables);
            Restaurant Rest = manager.GetRestaurant(model.RestaurantId);
            ViewBag.UserId = manager.GetCurrectUserId();
            return PartialView("~/Views/Restaurant/_ReservedTablesPartial.cshtml", Rest);
        }

        public async Task<ActionResult> Schema(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            RestaurantSchema Schema = manager.GetRestaurantSchema(id);
            RestaurantShemaViewModel schema = manager.GetRestaurantViewModelSchema(id);

            if (Schema == null)
            {
                return HttpNotFound();
            }

            return View(schema);
        }



        //[HttpPost]
        //public ActionResult Schema(Models.ViewModels.RestaurantShemaViewModel model)
        //{
        //    RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
        //    IRestaurantDataManager manager = factory.GetManager();
        //    //manager.ReservTables(model.Tables);
        //    Restaurant Rest = manager.GetRestaurant(1);
        //    ViewBag.UserId = manager.GetCurrectUserId();

        //    return View();
        //    //return PartialView("~/Views/Restaurant/_ReservedTablesPartial.cshtml", Rest);
        //}

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/SchemaReservedTables
        public ActionResult SchemaReservedTables(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            RestaurantSchema Schema = manager.GetRestaurantSchema(id);
            RestaurantShemaViewModel schema = manager.GetRestaurantViewModelSchema(id);

            if (Schema == null)
            {
                return HttpNotFound();
            }
            return PartialView(schema);
        }
        
        [AjaxOnly]
        public async Task<ActionResult> EventsSearch(string searchText)
        {
            string CheckEl = Request.Form["EventTypesCheck"];
            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            try
            {
                var RestaurantEvent = manager.SearchEvents(searchText, CheckEl);

                if (RestaurantEvent.Count > 0)
                {
                    RestaurantEvent = RestaurantEvent.Distinct().ToList();

                }
                return PartialView(RestaurantEvent);
            }
            catch
            {
                return PartialView(new List<RestaurantEvent>() );
            }            
        }

        [AjaxOnly]
        public async Task<ActionResult> RestaurantsSearch(string searchText)
        {
            string CuisinesCheck = Request.Form["CuisinesCheck"];
            string FeaturesCheck = Request.Form["FeaturesCheck"];
            string MealGroups = Request.Form["MealGroups"];
            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            try
            {
                var Restaurants = manager.SearchRestaurants(searchText, CuisinesCheck, FeaturesCheck, MealGroups);

                if (Restaurants.Count > 0)
                {
                    Restaurants = Restaurants.Distinct().ToList();
                }
                return PartialView(Restaurants);
            }
            catch
            {
                return PartialView(new List<Restaurant>());
            }
        }
    }
}