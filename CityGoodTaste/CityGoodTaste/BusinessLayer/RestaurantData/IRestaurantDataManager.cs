using CityGoodTaste.Models;
using System.Collections.Generic;
using System;
namespace CityGoodTaste.BusinessLayer
{
    public interface IRestaurantDataManager
    {
        EventSearchViewModel SearchEvents(string searchText, string CheckEl, DateTime from, DateTime to);
        void ConfirmReservTables(int restId, int schemaId, string userId, List<int> tablesIds, DateTime date, string contactName, string contactPhone);
        Menu GetRestMenu(int id);
        OrderFood GetOrderFood(int Id, int Value);
        int GetFoodRank(int? restId);
        int GetServiceRank(int? restId);
        int GetAmbienceRank(int? restId);
        double GetRestaurantRank(int? restId);
        void RemoveReserv(List<TableReservation> reservs);

        RestaurantSearchViewModel Restaurants();
        Restaurant GetRestaurant(int? id);
        List<EventType> GetEventTypes(List<int> idEl);
        List<Table> GetListTables(List<int> ids);
        RestaurantSchema GetRestaurantSchema(int? id);
        List<RestaurantEvent> GetListRestaurantEvents();
        EventSearchViewModel GetListEventSearch();
        List<RestaurantEvent> GetTopListRestaurantEvents();
        RestaurantShemaViewModel GetRestaurantViewModelSchema(int? id);
        void ReservTables(List<TableReservation> reservs);
        List<Restaurant> GetListRestaurants();
        List<Restaurant> GetFoundRestaurants(string searchTerm);
        RestaurantSearchViewModel SearchRestaurants(string searchText, string CuisinesCheck, string FeaturesCheck, string MealGroups, string Neighborhoods);
        void MakeReview(string userId, int restId, string text, int foodRank, int ambienceRank, int serviceRank);
        List<EventType> GetAllEventTypes();
        List<RestaurantFeature> GetAllRestaurantFeatures();
        List<Neighborhood> GetAllNeighborhoods();
        List<Cuisine> GetAllCuisines();
        List<MealGroup> GetAllMealGroups();
    }
}
