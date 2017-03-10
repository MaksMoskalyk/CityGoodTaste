using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityGoodTaste.Models;

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
        Restaurant GetRestaurant(int id, GoodTasteContext context);
    }

    public class RestaurantDataManager: IRestaurantDataManager
    {
        public Restaurant GetRestaurant(int id, GoodTasteContext context)
        {
            try
            {
                Restaurant r = (from x in context.Restaurants select x).Single();
                return context.Restaurants.Find(id);
            }
            catch
            {
                throw new Exception("Restaurant not found");
            }
        }
    }
}