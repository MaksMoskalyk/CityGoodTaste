using System;
using System.Collections.Generic;
using System.Linq;
using CityGoodTaste.Models;
using System.Data.Entity;
using CityGoodTaste.Models.ViewModels;


namespace CityGoodTaste.BusinessLayer
{
    public abstract class RestaurantDataManagerCreator
    {
        public abstract IRestaurantDataManager GetManager();
    }

    public class DefaultRestaurantDataManagerCreator : RestaurantDataManagerCreator
    {
        public override IRestaurantDataManager GetManager()
        {
            return new RestaurantDataManager();
        }
    }

    public interface IRestaurantDataManager
    {
        Restaurant GetRestaurant(int? id);
        List<Restaurant> GetListRestaurants();
        RestaurantSchema GetRestaurantSchema(int? id);
        List<RestaurantEvent> GetListRestaurantEvents();
        List<RestaurantEvent> GetTopListRestaurantEvents();
        RestaurantShemaViewModel GetRestaurantViewModelSchema(int? id);
        List<EventType> GetAllEventTypes();
        List<Cuisine> GetAllCuisines();
        List<RestaurantFeature> GetAllRestaurantFeatures();
        List<MealGroup> GetAllMealGroups();
        void ReservTables(List<TableViewModel> tables);
        string GetCurrectUserId();
        List<RestaurantEvent> SearchEvents(string searchText, string CheckEl);
        List<Restaurant> SearchRestaurants(string searchText, string CuisinesCheck, string FeaturesCheck, string MealGroups);
        void ConfirmReservTables(int restId, int schemaId, string userId, List<int> tablesIds);
    }

    public class RestaurantDataManager : IRestaurantDataManager
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
                            Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).Include(r => r.Photos).
                            Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                            Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                            Include(r => r.WorkHours).Where(r=>r.Id==id).FirstOrDefault();
                    result.City= context.Cities.Where(t => t.Id == result.City.Id).FirstOrDefault();
                    result.City.Country = context.Countries.Where(t => t.Id == result.City.Country.Id).FirstOrDefault();
                    result.Reviews = context.RestaurantReviews.Include(t => t.User).ToList();
                    result.RestaurantEvent = context.RestaurantEvent.Include(t => t.EventTypes).ToList();
                    result.Menu = context.Menus.Include(t => t.MealGroups.Select(m=>m.Meals)).ToList();
                    result.RestaurantSchemas = context.RestaurantSchemas.Include(t => t.Tables.Select(r => r.TableReservation.Select(u => u.User))).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurant not found");
                }
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
                           .Where(x => idEl.Contains(x.Id)).ToList();

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
                List<Restaurant> Restaurants = context.Restaurants.Include(t=>t.Menu
                    .Select(m=>m.MealGroups)).ToList();
                foreach (var Restaurant in Restaurants)
                {
                    foreach (var menu in Restaurant.Menu)
                    {
                        List<int> temp = new List<int>();
                        foreach (var mg in menu.MealGroups)
                        {
                            if(idEl.Contains(mg.Id))
                            {
                                temp.Add(Restaurant.Id);
                            }   
                        }
                        if(temp.Count== idEl.Count)
                            id.Add(Restaurant.Id);
                    }
                }
                return id;
            }
        }
        public List<Restaurant> SearchRestaurants(string searchText, string CuisinesCheck, string FeaturesCheck, string MealGroups)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Restaurant> result;
                    List<int> idRC = new List<int>();
                    List<int> idRF = new List<int>();
                    List<int> idRMG = new List<int>();
                    if (CuisinesCheck!=null)
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
                    if (idRC.Count>0|| idRF.Count > 0 || idRMG.Count > 0)
                    {
                        List<int> id = idRC.Intersect(idRF).ToList();
                        id = id.Intersect(idRMG).ToList();
                        if (searchText == null)
                        {
                            result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                           Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).Include(r => r.Photos).
                           Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                           Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                           Include(r => r.WorkHours).Where(t => id.Contains(t.Id)).ToList();
                        }
                        else
                        {
                            result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                           Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).Include(r => r.Photos).
                           Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                           Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                           Include(r => r.WorkHours).Where(t => id.Contains(t.Id))
                           .Where(t => t.Name.Contains(searchText)).ToList();
                        }
                        result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                            Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).Include(r => r.Photos).
                            Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                            Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                            Include(r => r.WorkHours).ToList();
                    }
                    else if (searchText.Length > 0)
                    {
                        result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                            Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).Include(r => r.Photos).
                            Include(r => r.RestaurantEvent).Include(r => r.RestaurantFeatures).Include(r => r.RestaurantGroup).
                            Include(r => r.RestaurantSchemas).Include(r => r.Reviews).Include(r => r.SpecialWorkHours).
                            Include(r => r.WorkHours).Where(t => t.Name.Contains(searchText)).ToList();
                    }
                    else
                    {
                        result = context.Restaurants.Include(r => r.City).Include(r => r.Cuisines).
                            Include(r => r.Likes).Include(r => r.Map).Include(r => r.Menu).Include(r => r.Photos).
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
        public List<EventType> GetAllEventTypes()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<EventType> result = context.EventTypes.ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Event types not found");
                }
            }

        }

        public List<Cuisine> GetAllCuisines()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<Cuisine> result = context.Cuisines.ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Cuisines not found");
                }
            }

        }
        public List<RestaurantFeature> GetAllRestaurantFeatures()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<RestaurantFeature> result = context.RestaurantFeatures.ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurant features not found");
                }
            }
        }

        public List<MealGroup> GetAllMealGroups()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    List<MealGroup> result = context.MealGroups.ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurant features not found");
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

        public void ReservTables(List<TableViewModel> tables)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                ApplicationUser currentUser = context.Users.FirstOrDefault();
                foreach (var item in tables)
                {
                    Table table = context.Tables.Find(item.Id);
                    TableReservation dbTableReservation = (table.TableReservation.Where(x => x.Date.Date == DateTime.Now.Date).Where(x => x.User == currentUser).Where(x => x.Table == table)).FirstOrDefault();

                    if (dbTableReservation != null)
                    {
                        dbTableReservation.Reserved = item.Reserved;
                    }
                    else
                    {
                        TableReservation reserv = new TableReservation { Date = DateTime.Now, Table = table, User = currentUser, Reserved = item.Reserved, ReservedAndConfirmed = false };
                        context.TableReservations.Add(reserv);
                    }
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

        public void ConfirmReservTables(int restId, int schemaId, string userId, List<int> tablesIds)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                ApplicationUser currentUser = context.Users.FirstOrDefault();
                var reservs = from x in currentUser.TableReservation 
                                where tablesIds.Contains(x.Table.Id) 
                                where x.Reserved==true
                                where x.ReservedAndConfirmed==false
                                select x;

                foreach (var reserv in reservs)
                {
                    reserv.ReservedAndConfirmed = true;
                    reserv.Reserved = false;
                }
                context.SaveChanges();
            }
        }
    }
}