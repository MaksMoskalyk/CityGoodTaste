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
        RestaurantSchema GetRestaurantSchema(int? id);
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

        public RestaurantSchema GetRestaurantSchema(int? id)
        {
            Restaurant r = this.GetRestaurant(id);
            return r.RestaurantSchemas.FirstOrDefault();
        }
    }


}