﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Collections.Generic;
using System;

namespace CityGoodTaste.Models
{
    public class GoodTasteDBInitializer : CreateDatabaseIfNotExists<GoodTasteContext>
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
            var user = new ApplicationUser { Email = "somemail2@mail.ru", UserName = "user", Name="Егор" };
            var result = userManager.Create(user, "Password!2");
            var user2 = new ApplicationUser { Email = "somemail22@mail.ru", UserName = "user2", Name = "Виктор" };
            var result2 = userManager.Create(user2, "Password!2");
            var user3 = new ApplicationUser { Email = "somemail3@mail.ru", UserName = "user3", Name = "Светлана" };
            var result3 = userManager.Create(user3, "Password!2");
            Restaurant r = new Restaurant
            {
                Name = "Три Резвых Коня",
                Address = "ул. Победы 6",
                ZipCode = 95009,
                AverageCheck = 305,
                Floors = 2,
                City=ct, 
                PhoneNumber="+380 97 725 83 65",
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

            RestaurantReview rr1 = new RestaurantReview { Text= "все понравилось. Сервис и еда вкусно", Restaurant=r, Date= DateTime.Now, User=user };
            RestaurantReview rr2 = new RestaurantReview { Text = "Очень мило и приятно проведен и отмечен праздник. Все на высоком уровне и очень культурно.", Restaurant = r, Date = DateTime.Now, User = user2 };
            RestaurantReview rr3 = new RestaurantReview { Text = "Кушал карбонару.Ничего осебенного но и цены тоже не кусаются. сервис хороший."+
                                                                 " скидку получили. У вас мало заведений на оболони, но проект очень нравится,"+
                                                                 " развивайтесь быстрее", Restaurant = r, Date = DateTime.Now, User = user3 };
            context.RestaurantReviews.Add(rr1);
            context.RestaurantReviews.Add(rr2);
            context.RestaurantReviews.Add(rr3);

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

            r.WorkHours = new List<WorkHour>();
            for (int i = 0; i < 7; i++)
            {
                WorkHour wh = new WorkHour { OpenHour = new System.TimeSpan(10, 0, 0), CloseHour = new System.TimeSpan(22, 0, 0) };
                r.WorkHours.Add(wh);
                context.WorkHours.Add(wh);
            }

            Like like = new Like { User = user, Restaurant = r };

            RestaurantSchema schema = new RestaurantSchema { Name = "1th Foor", InDoor = true, Restaurant = r, SmokingZone = false, XLength = 10, YLength = 10 };
            Table t1 = new Table { Seats = 4, X = 1, Y = 1 };
            Table t2 = new Table { Seats = 4, X = 3, Y = 1 };
            Table t3 = new Table { Seats = 4, X = 5, Y = 1 };
            Table t4 = new Table { Seats = 4, X = 1, Y = 3 };
            Table t5 = new Table { Seats = 4, X = 3, Y = 3 };
            Table t6 = new Table { Seats = 4, X = 5, Y = 3 };
            Table t7 = new Table { Seats = 4, X = 9, Y = 1 };
            Table t8 = new Table { Seats = 4, X = 9, Y = 3 };
            Table t9 = new Table { Seats = 4, X = 0, Y = 4 };
            Table t10 = new Table { Seats = 4, X = 0, Y = 6 };
            Table t11 = new Table { Seats = 4, X = 0, Y = 8 };
            Table t12 = new Table { Seats = 4, X = 3, Y = 4 };
            Table t13 = new Table { Seats = 4, X = 3, Y = 7 };
            Table t14 = new Table { Seats = 4, X = 3, Y = 9 };
            Table t15 = new Table { Seats = 4, X = 9, Y = 4 };
            Table t16 = new Table { Seats = 4, X = 9, Y = 5 };
            Table t17 = new Table { Seats = 4, X = 9, Y = 7 };
            Table t18 = new Table { Seats = 4, X = 9, Y = 9 };
            schema.Tables = new List<Table>();
            schema.Tables.Add(t1);
            schema.Tables.Add(t2);
            schema.Tables.Add(t3);
            schema.Tables.Add(t4);
            schema.Tables.Add(t5);
            schema.Tables.Add(t6);
            schema.Tables.Add(t7);
            schema.Tables.Add(t8);
            schema.Tables.Add(t9);
            schema.Tables.Add(t10);
            schema.Tables.Add(t11);
            schema.Tables.Add(t12);
            schema.Tables.Add(t13);
            schema.Tables.Add(t14);
            schema.Tables.Add(t15);
            schema.Tables.Add(t16);
            schema.Tables.Add(t17);
            schema.Tables.Add(t18);

            context.RestaurantSchemas.Add(schema);

            context.Likes.Add(like);
            context.Countries.Add(c);
            context.Cities.Add(ct);
            context.Restaurants.Add(r);
            context.EventTypes.Add(new Models.EventType() { Name = "EventTypes 1"});
            context.EventTypes.Add(new Models.EventType() { Name = "EventTypes 2" });
            context.EventTypes.Add(new Models.EventType() { Name = "EventTypes 3" });
            context.EventTypes.Add(new Models.EventType() { Name = "EventTypes 4" });
            context.Cuisines.Add(new Cuisine() { Name = "Cuisine 1" });
            context.Cuisines.Add(new Cuisine() { Name = "Cuisine 2" });
            context.Cuisines.Add(new Cuisine() { Name = "Cuisine 3" });
            context.Cuisines.Add(new Cuisine() { Name = "Cuisine 4" });
            context.Cuisines.Add(new Cuisine() { Name = "Cuisine 5" });
            context.Cuisines.Add(new Cuisine() { Name = "Cuisine 6" });
            context.MealGroups.Add(new MealGroup() { Name = "MealGroup 1" });
            context.MealGroups.Add(new MealGroup() { Name = "MealGroup 2" });
            context.MealGroups.Add(new MealGroup() { Name = "MealGroup 3" });
            context.MealGroups.Add(new MealGroup() { Name = "MealGroup 4" });
            context.MealGroups.Add(new MealGroup() { Name = "MealGroup 5" });
            context.RestaurantEvent.Add(new RestaurantEvent("Restaurant Event 1", "Restaurant Event 1 Description",  DateTime.Now, DateTime.Now.AddHours(4), r));
            context.RestaurantEvent.Add(new RestaurantEvent("Restaurant Event 2", "Restaurant Event 2 Description", DateTime.Now, DateTime.Now.AddHours(4), r));
            context.RestaurantEvent.Add(new RestaurantEvent("Restaurant Event 3", "Restaurant Event 3 Description", DateTime.Now, DateTime.Now.AddHours(4), r));
            context.RestaurantEvent.Add(new RestaurantEvent("Restaurant Event 4", "Restaurant Event 4 Description", DateTime.Now, DateTime.Now.AddHours(4), r));
            context.RestaurantEvent.Add(new RestaurantEvent("Restaurant Event 5", "Restaurant Event 5 Description", DateTime.Now, DateTime.Now.AddHours(4), r));
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