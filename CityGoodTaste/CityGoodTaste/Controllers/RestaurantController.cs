using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CityGoodTaste.BusinessLayer;
using CityGoodTaste.Models;

namespace CityGoodTaste.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {

            RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            IRestaurantDataManager manager = factory.GetManager();
            List<Restaurant> Restaurants = manager.GetListRestaurants();
            return View(Restaurants);
        }
        // POST: Restaurant/Events
        [HttpPost]
        public ActionResult Index(int? id)
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

        // POST: Restaurant/Events
        [HttpPost]
        public ActionResult Events(int? id)
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

            if (Rest == null)
            {
                return HttpNotFound();
            }
            return View(Rest);

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

            if (Schema == null)
            {
                return HttpNotFound();
            }
            return View(Schema);

        }

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
    }
}
