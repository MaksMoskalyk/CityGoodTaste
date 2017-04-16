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

namespace CityGoodTaste.Controllers
{
    public class AdministrationController : Controller
    {
        private GoodTasteContext db = new GoodTasteContext();

        // GET: Administrations
        public ActionResult Index()
        {
            DataManagerCreator creator = new DefaultDataManagerCreator();
            IAdministrationDataManager manager = creator.GetAdministrationDataManager();
            Administration model = manager.GetAdministration(1);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        // GET: Administrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] Administration administration)
        {
            if (ModelState.IsValid)
            {
                db.Administrations.Add(administration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(administration);
        }

        // GET: Administrations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administration administration = await db.Administrations.FindAsync(id);
            if (administration == null)
            {
                return HttpNotFound();
            }
            return View(administration);
        }

        // POST: Administrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Administration administration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administration).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(administration);
        }

        // GET: Administrations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administration administration = await db.Administrations.FindAsync(id);
            if (administration == null)
            {
                return HttpNotFound();
            }
            return View(administration);
        }

        // POST: Administrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Administration administration = await db.Administrations.FindAsync(id);
            db.Administrations.Remove(administration);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [AjaxOnly]
        public ActionResult ConfirmReserv(string restId, string schemaId)
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
            IAdministrationDataManager adminmanager = factory.GetAdministrationDataManager();
            adminmanager.ConfirmReservTables(Convert.ToInt32(restId), Convert.ToInt32(schemaId), userId, tablesIds);
            
            return Json(manager.GetUser(userId).Name);
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
