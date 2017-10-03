using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityGoodTaste.Models.ViewModels
{
    public class RestaurantSearchViewModel
    {
        public List<Restaurant> Restaurants { set; get; }
        public List<SearchCategory<Neighborhood>> Neighborhoods { set; get; }
        public List<SearchCategory<RestaurantFeature>> RestaurantFeatures { set; get; }
        public List<SearchCategory<Cuisine>> Cuisines { set; get; }
        public List<SearchCategory<MealGroup>> MealGroups { set; get; }
    }
}