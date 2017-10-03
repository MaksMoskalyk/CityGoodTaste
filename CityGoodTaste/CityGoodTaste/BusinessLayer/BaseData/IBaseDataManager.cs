using CityGoodTaste.Models;


namespace CityGoodTaste.BusinessLayer
{
    public interface IBaseDataManager
    {
       string GetCurrectUserId();
       ApplicationUser GetUser(string id);
       ApplicationUser CreateUser(string name, string phone);
    }
}