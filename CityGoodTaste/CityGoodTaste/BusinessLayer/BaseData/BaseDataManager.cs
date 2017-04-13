using CityGoodTaste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CityGoodTaste.Models.ViewModels;


namespace CityGoodTaste.BusinessLayer
{
    public class BaseDataManager : IBaseDataManager
    {
        public Restaurant GetRestaurant(int? id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    //Restaurant Rest = context.Restaurants.Include(t => t.Likes).FirstOrDefault(t => t.Id == id);
                    //Rest = context.Restaurants.Include(t => t.City).FirstOrDefault(t => t.Id == id);
                    //Rest.City = context.Cities.Include(t => t.Country).FirstOrDefault(t => t.Country.Id == Rest.City.Country.Id);
                    //Rest = context.Restaurants.Include(t => t.RestaurantFeatures).FirstOrDefault(t => t.Id == id);
                    //Rest = context.Restaurants.Include(t => t.WorkHours).FirstOrDefault(t => t.Id == id);
                    //Rest = context.Restaurants.Include(t => t.Reviews).FirstOrDefault(t => t.Id == id);
                    //Rest.Reviews = context.RestaurantReviews.Include(t => t.User).ToList();
                    //Rest = context.Restaurants.Include(t => t.RestaurantSchemas).FirstOrDefault(t => t.Id == id);
                    //Rest.RestaurantSchemas = context.RestaurantSchemas.Include(t => t.Tables.Select(r => r.TableReservation.Select(u => u.User))).ToList();
                    //return Rest;
                    Restaurant result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                            Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).
                            Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                            Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                            Include(r => r.WorkHours).Where(r => r.Id == id).FirstOrDefault();
                    result.City = context.Cities.Where(t => t.Id == result.City.Id).FirstOrDefault();
                    result.City.Country = context.Countries.Where(t => t.Id == result.City.Country.Id).FirstOrDefault();
                    result.Reviews = context.RestaurantReviews.Include(t => t.User).ToList();
                    result.RestaurantEvent = context.RestaurantEvent.Include(t => t.EventTypes).ToList();
                    result.Menu = context.Menus.Include(t => t.MealGroups.Select(m => m.Meals.Select(c => c.Currency))).ToList();
                    result.RestaurantSchemas = context.RestaurantSchemas.Include(t => t.Tables.Select(r => r.TableReservation.Select(u => u.User))).ToList();
                    result.Map = context.Maps.Where(x => x.id == result.Map.id).SingleOrDefault();
                    return result;
                }
                catch
                {
                    throw new Exception(CityGoodTaste.Resources.Resource.ErNotFundRest);
                }
            }

        }

        public List<RestaurantEvent> GetListRestaurantEvents()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<RestaurantEvent> result = context.RestaurantEvent.Include(t => t.Restaurant)
                        .Include(t => t.EventTypes).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Events not found");
                }
            }

        }

        private List<EventType> GetEventTypes(List<int> idEl)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                List<EventType> EventTypes = new List<EventType>();

                EventTypes = context.EventTypes.Include(t => t.RestaurantEvents)
                           .Where(x => idEl.Contains(x.Id)).OrderBy(x => x.Name).ToList();

                return EventTypes;
            }
        }

        public List<RestaurantEvent> SearchEvents(string searchText, string CheckEl)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<RestaurantEvent> result;
                    if (CheckEl != null)
                    {
                        string[] el = CheckEl.Split(',');
                        List<int> idEl = new List<int>();
                        for (int i = 0; i < el.Count(); i++)
                        {
                            idEl.Add(int.Parse(el[i].Trim()));
                        }

                        var re = GetEventTypes(idEl).Select(t => t.RestaurantEvents).ToList();

                        List<int> id = new List<int>();
                        for (int i = 0; i < re.Count(); i++)
                        {
                            for (int j = 0; j < re[i].ToList().Count(); j++)
                            {
                                id.Add(re[i].ToList()[j].Id);
                            }
                        }
                        id = id.Distinct().ToList();
                        if (searchText == null)
                        {
                            result = context.RestaurantEvent.Include(t => t.Restaurant)
                              .Include(t => t.EventTypes).Where(t => id.Contains(t.Id)).ToList();
                        }
                        else
                        {
                            result = context.RestaurantEvent.Include(t => t.Restaurant)
                             .Include(t => t.EventTypes).Where(t => id.Contains(t.Id))
                             .Where(t => t.Name.Contains(searchText)).ToList();
                        }
                    }
                    else if (searchText.Length > 0)
                    {
                        result = context.RestaurantEvent.Include(t => t.Restaurant)
                             .Include(t => t.EventTypes).Where(t => t.Name.Contains(searchText)).ToList();
                    }
                    else
                    {
                        result = context.RestaurantEvent.Include(t => t.Restaurant)
                             .Include(t => t.EventTypes).ToList();
                    }

                    return result;
                }
                catch
                {

                    throw new Exception("Events not found");
                }
            }
        }

        public List<RestaurantEvent> GetTopListRestaurantEvents()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<RestaurantEvent> result = context.RestaurantEvent.Include(t => t.Restaurant).ToList();
                    if (result.Count > 10)
                        result.RemoveRange(10, result.Count - 9);
                    return result;
                }
                catch
                {
                    throw new Exception("Events not found");
                }
            }
        }

               
        public RestaurantSchema GetRestaurantSchema(int? id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    Restaurant Rest = context.Restaurants.Find(id);
                    RestaurantSchema Schema = Rest.RestaurantSchemas.FirstOrDefault();
                    Schema = context.RestaurantSchemas.Include(t => t.Restaurant).FirstOrDefault(t => t.Id == id);
                    Schema = context.RestaurantSchemas.Include(t => t.Tables).FirstOrDefault();
                    Schema.Tables = context.Tables.Include(t => t.TableReservation.Select(x=>x.User)).ToList();
                    Schema.Tables = context.Tables.Include(t => t.Orders).ToList();
                    return Schema;
                }
                catch
                {
                    throw new Exception("Restaurant not found");
                }
            }
        }

        public RestaurantShemaViewModel GetRestaurantViewModelSchema(int? id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    Restaurant Rest = context.Restaurants.Find(id);
                    RestaurantSchema Schema = Rest.RestaurantSchemas.FirstOrDefault();
                    Schema = context.RestaurantSchemas.Include(t => t.Restaurant).FirstOrDefault(t => t.Id == id);
                    Schema = context.RestaurantSchemas.Include(t => t.Tables).FirstOrDefault();
                    RestaurantShemaViewModel vmSchema = new RestaurantShemaViewModel();
                    vmSchema.Id = Schema.Id;
                    vmSchema.Name = Schema.Name;
                    vmSchema.RestaurantId = Convert.ToInt32(id);
                    List<TableViewModel> vmTables = new List<TableViewModel>();

                    foreach (var table in Schema.Tables)
                    {
                        TableViewModel vmTable = new TableViewModel { Id = table.Id, X = table.X, Y = table.Y, Seats = table.Seats, ReservedAndConfirmed = false, Reserved = false };
                        foreach (var reserv in table.TableReservation)
                        {
                            if (reserv.Date.Date == DateTime.Now.Date && reserv.ReservedAndConfirmed == true)
                            {
                                vmTable.ReservedAndConfirmed = true;
                                break;
                            }
                            else if (reserv.Date.Date == DateTime.Now.Date && reserv.Reserved == true)
                            {
                                vmTable.Reserved = true;
                                break;
                            }
                        }
                        vmTables.Add(vmTable);
                    }

                    vmSchema.Tables = vmTables;
                    vmSchema.XLength = Schema.XLength;
                    vmSchema.YLength = Schema.YLength;
                    return vmSchema;
                }
                catch
                {
                    throw new Exception("Restaurant not found");
                }
            }
        }

        public void ReservTables(List<TableReservation> reservs)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                foreach (var item in reservs)
                {
                    Table t = context.Tables.Where(x => x.Id == item.Table.Id).FirstOrDefault();
                    ApplicationUser u = context.Users.Find(item.User.Id);
                    TableReservation r = new TableReservation { Date = DateTime.Now, Reserved = true, ReservedAndConfirmed = false, User = u, Table = t };
                    t.TableReservation.Add(r);
                    context.TableReservations.Add(r);
                }
                context.SaveChanges();
            }
        }

        public void RemoveReserv(List<TableReservation> reservs)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                foreach (var item in reservs)
                {
                    TableReservation remove = context.TableReservations.Find(item.Id);
                    context.TableReservations.Remove(remove);
                }
                context.SaveChanges();
            }
        }

        public string GetCurrectUserId()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                //ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == HttpContext.Current.User.Identity.GetUserId());
                ApplicationUser user = context.Users.FirstOrDefault();
                return user.Id;
            }
        }

        public Menu GetRestMenu(int id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    Menu menu = context.Menus.Include(t => t.MealGroups.Select(m => m.Meals.Select(c => c.Currency))).Where(t => t.Restaurant.Id == id).FirstOrDefault();
                    return menu;
                }
                catch
                {
                    throw new Exception("Menu not found");
                }
            }

        }

        public void ConfirmReservTables(int restId, int schemaId, string userId, List<int> tablesIds)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                ApplicationUser currentUser = context.Users.FirstOrDefault();
                var reservs = from x in currentUser.TableReservation
                              where tablesIds.Contains(x.Table.Id)
                              where x.Reserved == true
                              where x.ReservedAndConfirmed == false
                              select x;

                foreach (var reserv in reservs)
                {
                    reserv.ReservedAndConfirmed = true;
                    reserv.Reserved = false;
                }
                context.SaveChanges();
            }
        }

        public List<Table> GetListTables(List<int> ids)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Table> Tables = context.Tables.Where(t => ids.Contains(t.Id)).ToList();
                    return Tables;
                }
                catch
                {
                    throw new Exception("Tables not found");
                }
            }
        }
        public OrderFood GetOrderFood(int Id, int value)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    OrderFood OF = new Models.OrderFood();
                    return OF;
                }
                catch
                {
                    throw new Exception("Order food not found");
                }
            }
        }

        public int GetFoodRank(int? restId)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                List<RestaurantReview> reviews = (from x in context.RestaurantReviews
                                                  where x.Restaurant.Id == restId
                                                  select x).ToList();
                int count = 0;
                int totalRank = 0;
                foreach (var item in reviews)
                {
                    totalRank += item.FoodRank;
                    if (item.FoodRank > 0)
                        count++;
                }
                if (count == 0)
                {
                    return 1;
                }
                return totalRank / count;
            }
        }
        public int GetServiceRank(int? restId)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                List<RestaurantReview> reviews = (from x in context.RestaurantReviews
                                                  where x.Restaurant.Id == restId
                                                  select x).ToList();
                int count = 0;
                int totalRank = 0;
                foreach (var item in reviews)
                {
                    totalRank += item.ServiceRank;
                    if (item.FoodRank > 0)
                        count++;
                }
                if (count == 0)
                {
                    return 1;
                }
                return totalRank / count;
            }
        }
        public int GetAmbienceRank(int? restId)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                List<RestaurantReview> reviews = (from x in context.RestaurantReviews
                                                  where x.Restaurant.Id == restId
                                                  select x).ToList();
                int count = 0;
                int totalRank = 0;
                foreach (var item in reviews)
                {
                    totalRank += item.AmbienceRank;
                    if (item.FoodRank > 0)
                        count++;
                }
                if (count == 0)
                {
                    return 1;
                }
                return totalRank / count;
            }
        }
        public double GetRestaurantRank(int? restId)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                List<RestaurantReview> reviews = (from x in context.RestaurantReviews
                                                  where x.Restaurant.Id == restId
                                                  select x).ToList();
                double rank = 0;
                int count = 0;
                for (int i = 0; i < reviews.Count; i++)
                {
                    rank += reviews[i].Rank;
                    if (reviews[i].Rank > 0)
                        count++;
                }
                if (count == 0)
                    return 0;

                return Math.Round(rank / count, 1);
            }
        }
        public ApplicationUser GetUser(string id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                return (from x in context.Users where x.Id == id select x).FirstOrDefault();
            }
        }
    }
}