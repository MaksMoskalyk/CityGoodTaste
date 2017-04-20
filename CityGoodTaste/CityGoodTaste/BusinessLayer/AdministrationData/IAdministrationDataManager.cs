using CityGoodTaste.Models;
using CityGoodTaste.Models.ViewModels;
using System.Collections.Generic;
using System;

namespace CityGoodTaste.BusinessLayer
{
    public interface IAdministrationDataManager
    {
        Administration GetAdministration(int? id);
        void ConfirmReservTables(int restId, int schemaId, List<int> tablesIds, DateTime date, ApplicationUser user, string name, string phone);
        void RemoveReserv(int? reservId);
        void ConfirmReservByAdministration(int reservId);
    }
}