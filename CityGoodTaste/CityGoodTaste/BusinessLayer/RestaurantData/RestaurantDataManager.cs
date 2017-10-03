﻿using CityGoodTaste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace CityGoodTaste.BusinessLayer
{
    public class RestaurantDataManager : IRestaurantDataManager
    {
        public Restaurant GetRestaurant(int? id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
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
                catch (Exception ex)
                {
                    throw new Exception("");
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
        public EventSearchViewModel GetListEventSearch()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<RestaurantEvent> EventList = context.RestaurantEvent.Include(t => t.Restaurant)
                        .Include(t => t.EventTypes).ToList();
                    List<EventType> EventTypes = context.EventTypes.Include(t => t.RestaurantEvents).Where(t=> t.RestaurantEvents.Count>0).OrderBy(t=>t.Name).ToList();
                    List<SearchCategory<EventType>> EventTypesInfo = new List<SearchCategory<EventType>>();

                    for (int i =0;i<EventTypes.Count; i++)
                    {
                        EventTypesInfo.Add(new SearchCategory<EventType>() { Category = EventTypes[i],IsSelected=false,Count= GetEventCountByType(EventTypes[i].Id) });
                    }
                    EventSearchViewModel result = new Models.EventSearchViewModel();
                    result.Events = EventList;
                    result.Types = EventTypesInfo;
                    result.IsSelectedAnyCategory = false;
                    return result;
                }
                catch
                {
                    throw new Exception("Events not found");
                }
            }

        }
        public List<EventType> GetEventTypes(List<int> idEl)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                List<EventType> EventTypes = new List<EventType>();

                EventTypes = context.EventTypes.Include(t => t.RestaurantEvents)
                           .Where(x => idEl.Contains(x.Id)).OrderBy(x => x.Name).ToList();

                return EventTypes;
            }
        }

        public EventSearchViewModel SearchEvents(string searchText, string CheckEl, DateTime from, DateTime to)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    EventSearchViewModel result = new EventSearchViewModel();
                    List<RestaurantEvent> EventList = new List<RestaurantEvent> ();
                    List<EventType> EventTypes = new List<EventType>();
                    List<SearchCategory<EventType>> EventTypesInfo = new List<SearchCategory<EventType>>();
                    bool IsSelectedAnyCategory = false;

                    if (CheckEl != null)
                    {
                        IsSelectedAnyCategory = true;
                        string[] el = CheckEl.Split(',');
                        List<int> idEl = new List<int>();
                        for (int i = 0; i < el.Count(); i++)
                        {
                            idEl.Add(int.Parse(el[i].Trim()));
                        }


                        List<EventType> SelEventTypes = GetEventTypes(idEl);

                        var re = SelEventTypes.Select(t => t.RestaurantEvents).ToList();

                        List<int> id = new List<int>();
                        for (int i = 0; i < re.Count(); i++)
                        {
                            for (int j = 0; j < re[i].ToList().Count(); j++)
                            {
                                id.Add(re[i].ToList()[j].Id);
                            }
                        }
                        id = id.Distinct().ToList();
                        if (searchText == null || searchText == "")
                        {
                            EventList = context.RestaurantEvent.Include(t => t.Restaurant)
                              .Include(t => t.EventTypes).Where(t => id.Contains(t.Id)).ToList();
                        }
                        else
                        {
                            EventList = context.RestaurantEvent.Include(t => t.Restaurant)
                             .Include(t => t.EventTypes).Where(t => id.Contains(t.Id))
                             .Where(t => t.Name.Contains(searchText)).ToList();
                        }

                        EventTypes = context.EventTypes.Include(t => t.RestaurantEvents).Where(t => t.RestaurantEvents.Count > 0).OrderBy(t => t.Name).ToList();
                        for (int i = 0; i < EventTypes.Count; i++)
                        {
                            bool IsSelected = idEl.Contains(EventTypes[i].Id);
                            int Count = EventList.Where(t => t.EventTypes.Contains(EventTypes[i])).ToList().Count();
                            EventTypesInfo.Add(new SearchCategory<EventType>() { Category = EventTypes[i],
                                IsSelected = IsSelected,
                                Count = Count
                            });
                            
                        }
                    }
                    else
                    {
                        if (searchText.Length > 0)
                        {
                            EventList = context.RestaurantEvent.Include(t => t.Restaurant)
                                 .Include(t => t.EventTypes).Where(t => t.Name.Contains(searchText)).ToList();
                        }
                        else
                        {
                            EventList = context.RestaurantEvent.Include(t => t.Restaurant)
                                 .Include(t => t.EventTypes).ToList();
                        }
                        EventTypes = context.EventTypes.Include(t => t.RestaurantEvents).Where(t => t.RestaurantEvents.Count > 0).OrderBy(t => t.Name).ToList();
                        for (int i = 0; i < EventTypes.Count; i++)
                        {
                            EventTypesInfo.Add(new SearchCategory<EventType>() { Category = EventTypes[i], IsSelected = false, Count = GetEventCountByType(EventTypes[i].Id) });
                        }
                    }

                    result.Events = EventList;
                    result.Types = EventTypesInfo;
                    result.IsSelectedAnyCategory = IsSelectedAnyCategory;
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
                    Schema.Tables = context.Tables.Include(t => t.TableReservation.Select(x => x.User)).ToList();
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

        public void ConfirmReservTables(int restId, int schemaId, string userId, List<int> tablesIds, DateTime date, string contactName, string contactPhone)
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
                    reserv.Date = date;
                    reserv.ContactInfoName = contactName.Trim();
                    reserv.ContactInfoPhone = contactPhone.Trim();
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

        public int GetEventCountByType(int id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                var temp = context.RestaurantEvent.Include(t => t.EventTypes).Where(e => e.EventTypes.Select(x => x.Id).ToList().Contains(id)).ToList();
                return temp.Count>=0? temp.Count:0;
            }
        }
        public List<Restaurant> GetListRestaurants()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Restaurant> result = context.Restaurants.Include(t => t.Likes).Include(t => t.City).
                        Include(t => t.RestaurantFeatures).Include(t => t.Reviews).Include(t => t.WorkHours).
                        Include(t => t.Cuisines).Include(t => t.Likes).Include(t => t.RestaurantFeatures).Include(t => t.RestaurantGroup).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurants not found");
                }
            }

        }
        public List<Restaurant> GetFoundRestaurants(string searchTerm)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Restaurant> result = context.Restaurants.Include(t => t.Likes).Include(t => t.City).Include(t => t.City.Country).
                        Include(t => t.RestaurantFeatures).Include(t => t.Reviews).Include(t => t.WorkHours).
                        Include(t => t.Cuisines).Include(t => t.Likes).Include(t => t.RestaurantFeatures).Include(t => t.RestaurantGroup)
                        .Where(r => r.Name.Contains(searchTerm)).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurants not found");
                }
            }
        }
        public List<Restaurant> SearchRestaurants(string searchText, string CuisinesCheck, string FeaturesCheck, string MealGroups, string Neighborhoods)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Restaurant> result;
                    List<int> idRC = new List<int>();
                    List<int> idRF = new List<int>();
                    List<int> idRMG = new List<int>();
                    List<int> idNB = new List<int>();
                    if (CuisinesCheck != null)
                    {
                        string[] el = CuisinesCheck.Split(',');
                        List<int> idEl = new List<int>();
                        for (int i = 0; i < el.Count(); i++)
                        {
                            idEl.Add(int.Parse(el[i].Trim()));
                        }
                        idRC = GetRestaurantsByCuisines(idEl);
                    }
                    if (FeaturesCheck != null)
                    {
                        string[] el = FeaturesCheck.Split(',');
                        List<int> idEl = new List<int>();
                        for (int i = 0; i < el.Count(); i++)
                        {
                            idEl.Add(int.Parse(el[i].Trim()));
                        }
                        idRF = GetRestaurantsByFeatures(idEl);
                    }
                    if (MealGroups != null)
                    {
                        string[] el = MealGroups.Split(',');
                        List<int> idEl = new List<int>();
                        for (int i = 0; i < el.Count(); i++)
                        {
                            idEl.Add(int.Parse(el[i].Trim()));
                        }
                        idRMG = GetRestaurantsByMealGroups(idEl);
                    }
                    if (Neighborhoods != null)
                    {
                        string[] el = Neighborhoods.Split(',');
                        List<int> idEl = new List<int>();
                        for (int i = 0; i < el.Count(); i++)
                        {
                            idEl.Add(int.Parse(el[i].Trim()));
                        }
                        idNB = GetRestaurantsByNeighborhoods(idEl);
                    }
                    if (idRC.Count > 0 || idRF.Count > 0 || idRMG.Count > 0 || idNB.Count > 0)
                    {
                        List<int> id = idRC;
                        if (id.Count > 0 && idRF.Count > 0)
                            id = id.Intersect(idRF).ToList();
                        else if (idRF.Count > 0)
                            id = idRF;

                        if (id.Count > 0 && idRMG.Count > 0)
                            id = id.Intersect(idRMG).ToList();
                        else if (idRMG.Count > 0)
                            id = idRMG;
                        if (id.Count > 0 && idNB.Count > 0)
                            id = id.Intersect(idNB).ToList();
                        else if (idNB.Count > 0)
                            id = idNB;

                        if (searchText == null)
                        {
                            result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                           Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).
                           Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                           Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                           Include(r => r.WorkHours).Where(t => id.Contains(t.Id)).ToList();
                        }
                        else
                        {
                            result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                           Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).
                           Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                           Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                           Include(r => r.WorkHours).Where(t => id.Contains(t.Id))
                           .Where(t => t.Name.Contains(searchText)).ToList();
                        }
                    }
                    else if (searchText.Length > 0)
                    {
                        result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                            Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).
                            Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                            Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                            Include(r => r.WorkHours).Where(t => t.Name.Contains(searchText)).ToList();
                    }
                    else
                    {
                        result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                            Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).
                            Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                            Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                            Include(r => r.WorkHours).ToList();
                    }
                    return result;
                }
                catch
                {

                    throw new Exception("Restaurants not found");
                }
            }
        }
        public void MakeReview(string userId, int restId, string text, int foodRank, int ambienceRank, int serviceRank)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                ApplicationUser currentUser = context.Users.FirstOrDefault();
                Restaurant rest = context.Restaurants.Find(restId);

                int s = 0;
                if (foodRank > 0)
                    s++;
                if (ambienceRank > 0)
                    s++;
                if (serviceRank > 0)
                    s++;

                double rank = 0;
                if (s != 0)
                    rank = (foodRank + ambienceRank + serviceRank) / s;

                RestaurantReview review = new RestaurantReview
                {
                    Text = text.Trim(),
                    User = currentUser,
                    Restaurant = rest,
                    Date = DateTime.Now,
                    FoodRank = foodRank,
                    AmbienceRank = ambienceRank,
                    ServiceRank = serviceRank,
                    Rank = s
                };
                context.RestaurantReviews.Add(review);
                context.SaveChanges();
            }
        }
        private List<int> GetRestaurantsByCuisines(List<int> idEl)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                List<int> id = new List<int>();
                var rest = context.Cuisines.Include(t => t.Restaurants)
                           .Where(x => idEl.Contains(x.Id)).Select(t => t.Restaurants).ToList();

                for (int i = 0; i < rest.Count(); i++)
                {
                    List<int> temp = new List<int>();
                    for (int j = 0; j < rest[i].ToList().Count(); j++)
                    {
                        temp.Add(rest[i].ToList()[j].Id);
                    }
                    if (id.Count > 0)
                        id = id.Intersect(temp).ToList();
                    else
                        id = temp;
                }
                return id;
            }
        }
        private List<int> GetRestaurantsByFeatures(List<int> idEl)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {

                List<int> id = new List<int>();
                var rest = context.RestaurantFeatures.Include(t => t.Restaurants)
                           .Where(x => idEl.Contains(x.Id)).Select(t => t.Restaurants).ToList();

                for (int i = 0; i < rest.Count(); i++)
                {
                    List<int> temp = new List<int>();
                    for (int j = 0; j < rest[i].ToList().Count(); j++)
                    {
                        temp.Add(rest[i].ToList()[j].Id);
                    }
                    if (id.Count > 0)
                        id = id.Intersect(temp).ToList();
                    else
                        id = temp;
                }
                return id;
            }
        }
        private List<int> GetRestaurantsByMealGroups(List<int> idEl)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                List<int> id = new List<int>();
                List<Restaurant> Restaurants = context.Restaurants.Include(t => t.Menu
                    .Select(m => m.MealGroups)).ToList();
                foreach (var Restaurant in Restaurants)
                {
                    foreach (var menu in Restaurant.Menu)
                    {
                        List<int> temp = new List<int>();
                        foreach (var mg in menu.MealGroups)
                        {
                            if (idEl.Contains(mg.Id))
                            {
                                temp.Add(Restaurant.Id);
                            }
                        }
                        if (temp.Count == idEl.Count)
                            id.Add(Restaurant.Id);
                    }
                }
                return id;
            }
        }
        private List<int> GetRestaurantsByNeighborhoods(List<int> idEl)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {

                List<int> id = new List<int>();
                var rest = context.Neighborhoods.Include(t => t.Restaurants)
                           .Where(x => idEl.Contains(x.Id)).Select(t => t.Restaurants).ToList();
                for (int i = 0; i < rest.Count(); i++)
                {
                    List<int> temp = new List<int>();
                    for (int j = 0; j < rest[i].ToList().Count(); j++)
                    {
                        temp.Add(rest[i].ToList()[j].Id);
                    }
                    if (id.Count > 0)
                        id = id.Intersect(temp).ToList();
                    else
                        id = temp;
                }
                return id;
            }
        }
        public List<EventType> GetAllEventTypes()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<EventType> result = context.EventTypes.OrderBy(x => x.Name).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Event types not found");
                }
            }

        }
        public List<RestaurantFeature> GetAllRestaurantFeatures()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<RestaurantFeature> result = context.RestaurantFeatures.OrderBy(x => x.Name).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurant features not found");
                }
            }
        }
        public List<Neighborhood> GetAllNeighborhoods()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Neighborhood> result = context.Neighborhoods.Where(n => n.City.Id == 1).OrderBy(x => x.Name).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Neighborhood features not found");
                }
            }
        }

        public List<Cuisine> GetAllCuisines()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Cuisine> result = context.Cuisines.OrderBy(x => x.Name).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Cuisines not found");
                }
            }
        }

        public List<MealGroup> GetAllMealGroups()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<MealGroup> result = context.MealGroups.OrderBy(x => x.Name).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurant features not found");
                }
            }
        }
    }
}