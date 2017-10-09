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
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IRestaurantDataManager manager = factory.GetRestaurantDataManager();
            IRestaurantDataManager rest_manager = factory.GetRestaurantDataManager();
            var Restaurants = rest_manager.Restaurants();
            if (Restaurants.Restaurants.Count > 1)
                return View(Restaurants);
            else if (Restaurants.Restaurants.Count == 1)
                return View("~/Views/Restaurant/Details.cshtml", manager.GetRestaurant(Restaurants.Restaurants[0].Id));
            else
                return View(rest_manager.Restaurants());
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
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IRestaurantDataManager manager = factory.GetRestaurantDataManager();
            var Events = manager.GetListEventSearch();
            return View(Events);
        }

        // GET: Restaurant/Details/5
        public async Task<ActionResult> EventDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IRestaurantDataManager manager = factory.GetRestaurantDataManager();
            RestaurantEvent RE = manager.GetListRestaurantEvents().Where(re => re.Id == id).FirstOrDefault();

            if (RE == null)
            {
                return HttpNotFound();
            }
            return View(RE);

        }
        // GET: Restaurant/Details/5
        public async Task<ActionResult> Details(int? id, int? idEvent)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IRestaurantDataManager manager = factory.GetRestaurantDataManager();
            IBaseDataManager BaseDataManager = factory.GetBaseDataManager();
            ViewBag.UserId = BaseDataManager.GetCurrectUserId();
            Restaurant Rest = new Restaurant();
            try
            {
                Rest = manager.GetRestaurant(id);
            }
            catch
            {
                id = 1;
                Rest = manager.GetRestaurant(id);
            }
            TempData["RestId"] = id;
            TempData["ReservDate"] = DateTime.Now.Date;
            ViewData["ReservDate"] = DateTime.Now.Date;
            ViewData["ReservDateStr"] = DateTime.Now.Date.ToString("dd.MM.yyyy");
            ViewData["foodRank"] = manager.GetFoodRank(id).ToString();
            ViewData["serviceRank"] = manager.GetServiceRank(id).ToString();
            ViewData["ambienceRank"] = manager.GetAmbienceRank(id).ToString();
            ViewData["restRank"] = manager.GetRestaurantRank(id).ToString();
            if (idEvent != null)
            {
                RestaurantEvent RE = manager.GetListRestaurantEvents().Where(re => re.Id == id).FirstOrDefault();
                ViewData["REdate"] = RE.StartDate.Ticks.ToString();
            }
            if (Rest == null)
            {
                return HttpNotFound();
            }

            for (int i = 0; i < Rest.RestaurantSchemas.FirstOrDefault().Tables.Count(); i++)
            {
                for (int j = 0; j < Rest.RestaurantSchemas.FirstOrDefault().Tables[i].TableReservation.Count(); j++)
                {
                    var reserv = Rest.RestaurantSchemas.FirstOrDefault().Tables[i].TableReservation[j];
                    if (DateTime.Now.Date.ToString("dd.MM.yyyy") != reserv.Date.Date.ToString("dd.MM.yyyy"))
                    {
                        Rest.RestaurantSchemas.FirstOrDefault().Tables[i].TableReservation.Remove(reserv);
                    }
                }
            }

            return View(Rest);

        }
        [AjaxOnly]
        public ActionResult _ReservedTablesPartial(RestaurantSchema model)
        {
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            var addReservs = (from x in model.Tables
                          from r in x.TableReservation
                          where r.Reserved == true && r.ReservedAndConfirmed == false && r.Id==0
                          select r).ToList();
            string userId = manager.GetCurrectUserId();
            DateTime reservDateFromTemp = Convert.ToDateTime(TempData["ReservDate"]);
            foreach (var item in addReservs)
            {
                item.User = manager.GetUser(userId);
                item.Date = reservDateFromTemp;
            }
            TempData["ReservDate"] = reservDateFromTemp;
            ViewData["ReservDate"] = reservDateFromTemp;
            manager.ReservTables(addReservs);

            var removeReserv = (from x in model.Tables
                            from r in x.TableReservation
                            where r.Reserved == false && r.ReservedAndConfirmed == false && r.Id>0
                            select r).ToList();
            manager.RemoveReserv(removeReserv);        

            Restaurant Rest = manager.GetRestaurant(model.Restaurant.Id);
            ViewBag.UserId = userId;
            ViewBag.SchemaId = Rest.RestaurantSchemas.FirstOrDefault().Id;
            return PartialView("~/Views/Restaurant/_ReservedTablesPartial.cshtml", Rest);
        }

        [AjaxOnly]
        public ActionResult ConfirmReservation(Restaurant model)
        {
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            string userId = manager.GetCurrectUserId();
            var schemaId = Request.Form["item.Id"];


            //RestaurantDataManagerCreator factory = new DefaultRestaurantDataManagerCreator();
            //IDataManager manager = factory.GetRestaurantDataManager();
            //manager.ReservTables(model.Tables);
            //Restaurant Rest = manager.GetRestaurant(model.RestaurantId);
            //ViewBag.UserId = manager.GetCurrectUserId();

            return View();
        }

        [AjaxOnly]
        public ActionResult MakeReview()
        {
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            string text = Request.Form["reviewText"];
            if(string.IsNullOrEmpty(text)||string.IsNullOrWhiteSpace(text))
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            string userId =  manager.GetCurrectUserId();
            int restId=Convert.ToInt32(TempData["RestId"]);
            int foodRank = Convert.ToInt32(Request.Form["ratingA"]);
            int serviceRank = Convert.ToInt32(Request.Form["ratingB"]);
            int ambienceRank = Convert.ToInt32(Request.Form["ratingC"]);
            TempData["RestId"] = restId;
            ViewData["NewReviewAdded"] = true;
            IRestaurantDataManager rest_manager = factory.GetRestaurantDataManager();
            rest_manager.MakeReview(userId, restId, text, foodRank, ambienceRank, serviceRank);
            Restaurant Rest = manager.GetRestaurant(restId);
            return PartialView("~/Views/Restaurant/_ReviewsPartial.cshtml", Rest);
        }

        public async Task<ActionResult> Schema(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
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
        //    IDataManager manager = factory.GetRestaurantDataManager();
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

        [AjaxOnly]
        public ActionResult ConfirmReserv(string restId, string schemaId, string date, string time, string name, string phone)
        {
            if (restId == null || schemaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            string userId =manager.GetCurrectUserId();

            List<int> tablesIds = new List<int>();
            foreach (string key in Request.Form.AllKeys)
            {
                if (key.StartsWith("tableId"))
                {
                    tablesIds.Add(Convert.ToInt32(Request.Form[key]));
                }
            }
            DateTime d = DateTime.Parse(date + " " + time);
            TempData["ReservDate"] = d;
            manager.ConfirmReservTables(Convert.ToInt32(restId), Convert.ToInt32(schemaId), userId, tablesIds, d , name, phone);


            //if (model == null)
            //{
            //    return HttpNotFound();
            //}
            //return PartialView(model);

            RestaurantSchema Schema = manager.GetRestaurantSchema(Convert.ToInt32(restId));
            TempData["RestId"] = restId;
            return PartialView("_SchemaReservedTablesPartial", Schema);
        }

        // GET: Restaurant/SchemaReservedTables
        public ActionResult SchemaReservedTables(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            RestaurantSchema Schema = manager.GetRestaurantSchema(id);

            if (Schema == null)
            {
                return HttpNotFound();
            }
            
            return PartialView(Schema);
        }
        
        [AjaxOnly]
        public async Task<ActionResult> EventsSearch(string searchText)
        {
            try
            {
                string CheckEl = Request.Form["EventTypesCheck"];
                DataManagerCreator factory = new DefaultDataManagerCreator();
                IRestaurantDataManager manager = factory.GetRestaurantDataManager();
                string from = Request.Form["from"];
                DateTime dtfrom = Convert.ToDateTime(from);
                string to = Request.Form["to"];
                DateTime dtto = Convert.ToDateTime(to);
                var RestaurantEvent = manager.SearchEvents(searchText, CheckEl, dtfrom, dtto);
                return PartialView(RestaurantEvent);

            }
            catch
            {
                return PartialView(new EventSearchViewModel());
            }
        }

        [AjaxOnly]
        public async Task<ActionResult> RestaurantsSearch(string searchText)
        {     
            try
            {
                string CuisinesCheck = Request.Form["CuisinesCheck"];
                string FeaturesCheck = Request.Form["RestaurantFeaturesCheck"];
                string MealGroups = Request.Form["MealGroupsCheck"];
                string Neighborhoods = Request.Form["NeighborhoodsCheck"];

                DataManagerCreator factory = new DefaultDataManagerCreator();
                IRestaurantDataManager manager = factory.GetRestaurantDataManager();
                var Restaurants = manager.SearchRestaurants(searchText, CuisinesCheck, FeaturesCheck, MealGroups, Neighborhoods);
                return PartialView(Restaurants);
            }
            catch
            {
                return PartialView(new RestaurantSearchViewModel());
            }
        }

        public async Task<ActionResult> ConfirmReserve(FormCollection collection)
        {
            try
            {
                var tenm = collection.AllKeys.ToList();
                var tabls = tenm.FindAll((x) => x.Contains(".Id"));
                List<int> tablIds = new List<int>();
                foreach (var t in tabls)
                {
                    int leng = t.IndexOf(']') - 1;
                    tablIds.Add(Convert.ToInt32(t.Substring(1, leng)));
                }
                string Id = Request.Form["Id"];
                string name = Request.Form["name"];
                string phone = Request.Form["phone"];
                string date = Request.Form["date"];
                string time = Request.Form["time"];

                DataManagerCreator factory = new DefaultDataManagerCreator();
                IRestaurantDataManager manager = factory.GetRestaurantDataManager();
                int lengId = Id.IndexOf(']') - 1;
                Restaurant Rest = manager.GetRestaurant(Convert.ToInt32(Id));
                List<Table> Tables = manager.GetListTables(tablIds);
                ConfirmReserve ConfirmReserve = new ConfirmReserve()
                {
                    UserName = name,
                    Phone = phone,
                    Date = date,
                    Time = time,
                    Tables = Tables,
                    Restaurant = Rest
                };
                return View(ConfirmReserve);
            }
            catch
            {
                return RedirectToAction("Index", new { id = 1 });
            }
        }
        public async Task<ActionResult> ConfirmReserveAddMeal(FormCollection collection)
        {
            try
            {
                OrderFood LOF = new OrderFood();
                string Id = Request.Form["Id"];
                string value = Request.Form["value"];
                TempData.Add("Food" + Id, "" + Id);
                TempData.Add("Value" + Id, "" + Id);
                //RestaurantDataManagerCreator factory = new DefaultDataManagerCreator();
                //IDataManager manager = factory.GetRestaurantDataManager();
                //LOF = manager.GetOrderFood(Convert.ToInt32(Id), Convert.ToInt32(value));
                return PartialView(LOF);
            }
            catch
            {
                return PartialView(new List<OrderFood>());
            }
        }
        public JsonResult GetSearchDataEvents(string term)
        {
            List<string> EventsNames;
            using (GoodTasteContext context = new GoodTasteContext())
            {
                EventsNames = context.RestaurantEvent.Where(r => r.Name.Contains(term)).Select(r => r.Name).ToList();
            }
            return Json(EventsNames, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSearchDataRestaurants(string term)
        {
            List<string> EventsNames;
            using (GoodTasteContext context = new GoodTasteContext())
            {
                EventsNames = context.Restaurants.Where(r => r.Name.Contains(term)).Select(r => r.Name).ToList();
            }
            return Json(EventsNames, JsonRequestBehavior.AllowGet);
        }



        [AjaxOnly]
        public ActionResult GetSchemaPartail(string reservdate)
        {
            int restId = Convert.ToInt32(TempData["RestId"]);
            ViewData["ReservDateStr"] = reservdate;
            ViewData["ReservDate"] = DateTime.Parse(reservdate.Replace('.','/'));
            TempData["ReservDate"] = DateTime.Parse(reservdate.Replace('.', '/'));
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            RestaurantSchema Schema = manager.GetRestaurantSchema(restId);
            for(int i=0; i < Schema.Tables.Count(); i++)
            {
                for (int j = 0; j < Schema.Tables[i].TableReservation.Count(); j++)
                {
                    var reserv = Schema.Tables[i].TableReservation[j];
                    if (reservdate != reserv.Date.Date.ToString("dd.MM.yyyy"))
                    {
                        Schema.Tables[i].TableReservation.Remove(reserv);
                    }
                }
            }
            TempData["RestId"] = restId;
            return PartialView("_SchemaReservedTablesPartial", Schema);
        }

    }
}