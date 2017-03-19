using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityGoodTaste.Models;
using System.Data.Entity;
using CityGoodTaste.Models.ViewModels;

namespace CityGoodTaste.BusinessLayer
{
    public interface IUserDatabase
    {
        ApplicationUser LogIn(string email, string password);

        void SignUp(ApplicationUser user);
    }
}
