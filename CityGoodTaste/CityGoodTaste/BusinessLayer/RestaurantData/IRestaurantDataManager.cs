using CityGoodTaste.Models;
using System.Collections.Generic;

namespace CityGoodTaste.BusinessLayer
{
    public interface IRestaurantDataManager
    {
        List<Restaurant> GetListRestaurants();
        List<Restaurant> GetFoundRestaurants(string searchTerm);
        List<Restaurant> SearchRestaurants(string searchText, string CuisinesCheck, string FeaturesCheck, string MealGroups, string Neighborhoods);
        void MakeReview(string userId, int restId, string text, int foodRank, int ambienceRank, int serviceRank);
        List<EventType> GetAllEventTypes();
        List<RestaurantFeature> GetAllRestaurantFeatures();
        List<Neighborhood> GetAllNeighborhoods();
        List<Cuisine> GetAllCuisines();
        List<MealGroup> GetAllMealGroups();
    }
}
