using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityGoodTaste.Models;
using System.Linq;
using System.Data.Entity;

namespace CityGoodTaste.BusinessLayer
{
    public class AdministrationDataManager : IAdministrationDataManager     
    {
        public Administration GetAdministration(int? id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                Administration model = context.Administrations.Find(id);
                model = context.Administrations.Include(r => r.Admins).FirstOrDefault();
                int qId = Convert.ToInt32(id);
                model = context.Administrations.Include(r => r.Restaurants).Where(x=>x.Restaurants.Select(r=>r.Administration.Id).Contains(qId)).FirstOrDefault();
                model.Restaurants = context.Restaurants.Include(r => r.RestaurantSchemas).Where(x=>x.Administration.Id==qId).ToList();
                foreach (var rest in model.Restaurants)
                {
                    rest.RestaurantSchemas = context.RestaurantSchemas.Include(t => t.Tables.Select(r => r.TableReservation.Select(u => u.User))).ToList();
                }

                return model;
            }
        }

        public void ConfirmReservTables(int restId, int schemaId, List<int> tablesIds, DateTime date, ApplicationUser user, string name, string phone)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                ApplicationUser u = null;
                if (user != null)
                     u = context.Users.Find(user.Id);

                foreach (var tableId in tablesIds)
                {
                    Table table = context.Tables.Find(tableId);
                    TableReservation reserv = new TableReservation();
                    reserv.Table = table;
                    reserv.User = u;
                    reserv.ReservedAndConfirmed = true;
                    reserv.Reserved = true;
                    reserv.Date = date;
                    reserv.ContactInfoName = name.Trim();
                    reserv.ContactInfoPhone = phone.Trim();
                    context.TableReservations.Add(reserv);
                }
                context.SaveChanges();
            }
        }

        public void RemoveReserv(int? reservId)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                context.TableReservations.Remove(context.TableReservations.Find(reservId));
                context.SaveChanges();
            }
        }
    }
}