using CityGoodTaste.Models;
using CityGoodTaste.Models.ViewModels;
using System.Collections.Generic;
using System;


namespace CityGoodTaste.BusinessLayer
{
    public interface IBaseDataManager
    {
        Restaurant GetRestaurant(int? id);
        List<Table> GetListTables(List<int> ids);
        RestaurantSchema GetRestaurantSchema(int? id);
        List<RestaurantEvent> GetListRestaurantEvents();
        List<RestaurantEvent> GetTopListRestaurantEvents();
        RestaurantShemaViewModel GetRestaurantViewModelSchema(int? id);             
        void ReservTables(List<TableReservation> reservs);
        string GetCurrectUserId();
        ApplicationUser GetUser(string id);
        List<RestaurantEvent> SearchEvents(string searchText, string CheckEl);
        void ConfirmReservTables(int restId, int schemaId, string userId, List<int> tablesIds, DateTime date, string contactName, string contactPhone);
        Menu GetRestMenu(int id);
        OrderFood GetOrderFood(int Id, int Value);
        int GetFoodRank(int? restId);
        int GetServiceRank(int? restId);
        int GetAmbienceRank(int? restId);
        double GetRestaurantRank(int? restId);
        void RemoveReserv(List<TableReservation> reservs);
        ApplicationUser CreateUser(string name, string phone);
    }
}