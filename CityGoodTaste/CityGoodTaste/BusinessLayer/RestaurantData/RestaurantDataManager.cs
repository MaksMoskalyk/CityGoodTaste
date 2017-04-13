using CityGoodTaste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace CityGoodTaste.BusinessLayer
{
    public class RestaurantDataManager : IRestaurantDataManager
    {
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