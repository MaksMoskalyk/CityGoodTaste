using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityGoodTaste.Models;
using System.Data.Entity;

namespace CityGoodTaste.BusinessLayer
{
    abstract class RestaurantDataManagerCreator
    {
        public abstract IRestaurantDataManager GetManager();
    }
    class DefaultRestaurantDataManagerCreator : RestaurantDataManagerCreator
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
    }

    public class RestaurantDataManager: IRestaurantDataManager
    {
        public Restaurant GetRestaurant(int? id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                try
                {
                    Restaurant Rest = context.Restaurants.Include(t => t.Likes).FirstOrDefault(t => t.Id == id);
                    Rest = context.Restaurants.Include(t => t.City).FirstOrDefault(t => t.Id == id);
                    Rest.City = context.Cities.Include(t => t.Country).FirstOrDefault(t => t.Country.Id == Rest.City.Country.Id);
                    Rest = context.Restaurants.Include(t => t.RestaurantFeatures).FirstOrDefault(t => t.Id == id);
                    Rest = context.Restaurants.Include(t => t.WorkHours).FirstOrDefault(t => t.Id == id);
                    Rest = context.Restaurants.Include(t => t.Reviews).FirstOrDefault(t => t.Id == id);
                    Rest.Reviews = context.RestaurantReviews.Include(t => t.User).ToList();
                    return Rest;
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
                    List<Restaurant> result = context.Restaurants.Include(t => t.Likes).Include(t => t.City).Include(t => t.RestaurantFeatures)
                        .Include(t => t.Reviews).Include(t => t.WorkHours).ToList();
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
                    List<RestaurantEvent> result = context.RestaurantEvent.Include(t =>t.Restaurant).ToList();
                    return result;
                }
                catch
                {
                    throw new Exception("Restaurants not found");
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
    }


}