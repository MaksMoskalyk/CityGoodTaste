using CityGoodTaste.Models;
using CityGoodTaste.Models.ViewModels;
using System.Collections.Generic;

namespace CityGoodTaste.BusinessLayer
{
    public interface IAdministrationDataManager
    {
        Administration GetAdministration(int? id);
        void ConfirmReservTables(int restId, int schemaId, string userId, List<int> tablesIds);
    }
}