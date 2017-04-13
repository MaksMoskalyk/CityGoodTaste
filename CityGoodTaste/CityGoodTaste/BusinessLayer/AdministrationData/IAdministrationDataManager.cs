using CityGoodTaste.Models;
using CityGoodTaste.Models.ViewModels;
using System.Collections.Generic;

namespace CityGoodTaste.BusinessLayer
{
    public interface IAdministrationDataManager
    {
        Administration GetAdministration(int? id);
    }
}