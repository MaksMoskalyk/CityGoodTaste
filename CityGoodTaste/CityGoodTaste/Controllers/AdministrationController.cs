using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CityGoodTaste.Models;
using CityGoodTaste.BusinessLayer;
using CityGoodTaste.CustomFilters;

namespace CityGoodTaste.Controllers
{
    [Culture]
    public class AdministrationController : Controller
    {
        private GoodTasteContext db = new GoodTasteContext();

        // GET: Administrations
        public ActionResult Index()
        {
            DataManagerCreator creator = new DefaultDataManagerCreator();
            IAdministrationDataManager manager = creator.GetAdministrationDataManager();
            Administration model = manager.GetAdministration(1);
            TempData["RestId"] = model.Restaurants.FirstOrDefault().Id;
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        [AjaxOnly]
        public ActionResult ConfirmReservation(string restId, string schemaId)
        {
            if (restId == null || schemaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            IRestaurantDataManager RestaurantDataManage = factory.GetRestaurantDataManager();
            string userId =manager.GetCurrectUserId();

            List<int> tablesIds = new List<int>();
            foreach (string key in Request.Form.AllKeys)
            {
                if (key.StartsWith("tableId"))
                {
                    tablesIds.Add(Convert.ToInt32(Request.Form[key]));
                }
            }
            string name = Request.Form["name"];
            string phone = Request.Form["phone"];

            string date = Request.Form["date"];
            string time = Request.Form["time"];
            DateTime d = DateTime.Parse(date + " " + time);

            IAdministrationDataManager adminmanager = factory.GetAdministrationDataManager();

            ApplicationUser user =  manager.CreateUser(name, phone);

            adminmanager.ConfirmReservTables(Convert.ToInt32(restId), Convert.ToInt32(schemaId), tablesIds, d, user, name, phone);

            return PartialView("~/Views/Administration/_SchemaAndInfoPartial.cshtml", RestaurantDataManage.GetRestaurantSchema(Convert.ToInt32(restId)));

        }


        [AjaxOnly]
        public ActionResult ConfirmClientReservation(string restId, string schemaId)
        {
            if (restId == null || schemaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            IAdministrationDataManager adminmanager = factory.GetAdministrationDataManager();

            IRestaurantDataManager RestaurantDataManage = factory.GetRestaurantDataManager();
            string reservId = Request.Form["reservnumber"];
            DateTime d = DateTime.Parse(Request.Form["date"] + " " + Request.Form["time"]);

            adminmanager.ConfirmReservByAdministration(Convert.ToInt32(reservId));

            return PartialView("~/Views/Administration/_SchemaAndInfoPartial.cshtml", RestaurantDataManage.GetRestaurantSchema(Convert.ToInt32(restId)));
        }

        [AjaxOnly]
        public ActionResult RemoveReservation(string restId)
        {
            int reservId = Convert.ToInt32(Request.Form["reservNumber"]);
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            IAdministrationDataManager adminmanager = factory.GetAdministrationDataManager();

            IRestaurantDataManager RestaurantDataManage = factory.GetRestaurantDataManager();
            adminmanager.RemoveReserv(reservId);
            return PartialView("~/Views/Administration/_SchemaAndInfoPartial.cshtml", RestaurantDataManage.GetRestaurantSchema(Convert.ToInt32(restId)));
        }

        [AjaxOnly]
        public ActionResult GetSchemaPartail(string reservdate)
        {
            int restId = Convert.ToInt32(TempData["RestId"]);
            DataManagerCreator factory = new DefaultDataManagerCreator();
            IBaseDataManager manager = factory.GetBaseDataManager();
            RestaurantSchema Schema = manager.GetRestaurantSchema(restId);
            for (int i = 0; i < Schema.Tables.Count(); i++)
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
            return PartialView("~/Views/Administration/_SchemaAndInfoPartial.cshtml", Schema);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
