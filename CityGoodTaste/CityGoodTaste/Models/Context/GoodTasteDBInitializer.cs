using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using CityGoodTaste.Models;
using System.Collections.Generic;

namespace CityGoodTaste
{
    public class GoodTasteDBInitializer : DropCreateDatabaseAlways<GoodTasteContext>
    {
        protected override void Seed(GoodTasteContext context)
        {
            InitializeAdminUserAndRoles(context);
            InitializeRestaurant(context);
            base.Seed(context);
        }



        private void InitializeRestaurant(GoodTasteContext context)
        {
            Country c = new Country { Name = "Украина" };
            City ct = new City { Name = "Одесса", Country = c };
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { Email = "somemail2@mail.ru", UserName = "user" };
            var result = userManager.Create(user, "Password!2");
            Restaurant r = new Restaurant
            {
                Name = "Три Резвых Коня",
                Address = "ул. Победы 6",
                ZipCode = 95009,
                AverageCheck = 305,
                Floors = 2,
                City=ct, 
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r"+ 
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную"+
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе,"+ 
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской,"+
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам,"+
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!"+
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!"+
                                    "У нас как в театре: хотите на класс – покупайте билет!"
            };

            RestaurantFeature f1 = new RestaurantFeature { Name = "WiFi" };
            RestaurantFeature f2 = new RestaurantFeature { Name = "Завтраки" };
            RestaurantFeature f3 = new RestaurantFeature { Name = "Живая Музыки" };
            RestaurantFeature f4 = new RestaurantFeature { Name = "Летняя площадка" };
            RestaurantFeature f5 = new RestaurantFeature { Name = "С животными" };
            RestaurantFeature f6 = new RestaurantFeature { Name = "Детское меню" };
            RestaurantFeature f7 = new RestaurantFeature { Name = "Бизнес ланч" };
            RestaurantFeature f8 = new RestaurantFeature { Name = "Детская площадка" };
            RestaurantFeature f9 = new RestaurantFeature { Name = "Детский стульчик" };
            RestaurantFeature f10 = new RestaurantFeature { Name = "Оплата кредитной картой" };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(f1);
            r.RestaurantFeatures.Add(f2);
            r.RestaurantFeatures.Add(f3);
            r.RestaurantFeatures.Add(f4);
            r.RestaurantFeatures.Add(f5);
            r.RestaurantFeatures.Add(f6);
            r.RestaurantFeatures.Add(f7);
            r.RestaurantFeatures.Add(f8);
            r.RestaurantFeatures.Add(f9);
            r.RestaurantFeatures.Add(f10);




            Like like = new Like { User = user, Restaurant = r };
            context.Likes.Add(like);
            context.Countries.Add(c);
            context.Cities.Add(ct);
            //context.RestaurantFeatures.Add(f1);
            //context.RestaurantFeatures.Add(f2);
            //context.RestaurantFeatures.Add(f3);
            //context.RestaurantFeatures.Add(f4);
            //context.RestaurantFeatures.Add(f5);
            //context.RestaurantFeatures.Add(f6);
            //context.RestaurantFeatures.Add(f7);
            //context.RestaurantFeatures.Add(f8);
            //context.RestaurantFeatures.Add(f10);
            context.Restaurants.Add(r);
            context.SaveChanges();
        }

        private void InitializeAdminUserAndRoles(GoodTasteContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "moderator" };
            var role3 = new IdentityRole { Name = "user" };
            var role4 = new IdentityRole { Name = "guest" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            roleManager.Create(role4);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "admin" };
            string password = "Password!2";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
        }
    }
}