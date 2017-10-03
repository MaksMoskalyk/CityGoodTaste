using CityGoodTaste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CityGoodTaste.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CityGoodTaste.BusinessLayer
{
    public class BaseDataManager : IBaseDataManager
    {

        public string GetCurrectUserId()
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                //ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == HttpContext.Current.User.Identity.GetUserId());
                ApplicationUser user = context.Users.FirstOrDefault();
                return user.Id;
            }
        }

        public ApplicationUser GetUser(string id)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                return (from x in context.Users where x.Id == id select x).FirstOrDefault();
            }
        }

        public ApplicationUser CreateUser(string name, string phone)
        {
            using (GoodTasteContext context = new GoodTasteContext())
            {
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

                // создаем пользователей
                var user = new ApplicationUser { PhoneNumber = phone, UserName = phone, Name= name };
                string password = "Password!2";
                var result = userManager.Create(user, password);

                // если создание пользователя прошло успешно
                if (result.Succeeded)
                {
                    // добавляем для пользователя роль
                    userManager.AddToRole(user.Id, "guest");
                    return user;
                }
                return null;
            }
            
        }
    }
}