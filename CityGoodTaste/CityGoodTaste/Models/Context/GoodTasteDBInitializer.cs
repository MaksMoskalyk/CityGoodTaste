using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Collections.Generic;
using System;

namespace CityGoodTaste.Models
{
    public class GoodTasteDBInitializer :CreateDatabaseIfNotExists<GoodTasteContext>
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
            Map map = new Map() { Latitude = 0, Longitude = 0, Zoom = 1 };
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Три Резвых Коня" };
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
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                 Map= map,
                 RestaurantGroup= restaurantsGroup
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
            Table t1 = new Table { Seats = 4, X = 1, Y = 1};
            Table t2 = new Table { Seats = 4, X = 3, Y = 1};
            Table t3 = new Table { Seats = 4, X = 5, Y = 1};
            Table t4 = new Table { Seats = 4, X = 1, Y = 3};
            Table t5 = new Table { Seats = 4, X = 3, Y = 3};
            Table t6 = new Table { Seats = 4, X = 5, Y = 3};
            Table t7 = new Table { Seats = 4, X = 9, Y = 1};
            Table t8 = new Table { Seats = 4, X = 9, Y = 3};
            Table t9 = new Table { Seats = 4, X = 0, Y = 4};
            Table t10 = new Table { Seats = 4, X = 0, Y = 6};
            Table t11 = new Table { Seats = 4, X = 0, Y = 8};
            Table t12 = new Table { Seats = 4, X = 3, Y = 4};
            Table t13 = new Table { Seats = 4, X = 3, Y = 7};
            Table t14 = new Table { Seats = 4, X = 3, Y = 9};
            Table t15 = new Table { Seats = 4, X = 9, Y = 4};
            Table t16 = new Table { Seats = 4, X = 9, Y = 5};
            Table t17 = new Table { Seats = 4, X = 9, Y = 7};
            Table t18 = new Table { Seats = 4, X = 9, Y = 9};

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

            EventType et1 =new EventType() { Name = "EventTypes 1" };
            EventType et2 = new EventType() { Name = "EventTypes 2" };
            EventType et3 = new EventType() { Name = "EventTypes 3" };
            EventType et4 = new EventType() { Name = "EventTypes 4" };

            context.EventTypes.Add(et1);
            context.EventTypes.Add(et2);
            context.EventTypes.Add(et3);
            context.EventTypes.Add(et4);

            List<EventType> let1 = new List<EventType>();
            let1.Add(et1);
            let1.Add(et3);

            List<EventType> let2 = new List<EventType>();
            let2.Add(et2);
            let2.Add(et4);

            List<EventType> let3 = new List<EventType>();
            let3.Add(et2);
            let3.Add(et3);

            List<EventType> let4 = new List<EventType>();
            let4.Add(et1);
            let4.Add(et4);

            RestaurantEvent re1 = new RestaurantEvent() { Name= "Restaurant Event 1",Description= "Restaurant Event 1 Description", StartDate= DateTime.Now , EndDate= DateTime.Now.AddHours(4) , Restaurant = r, EventTypes= let1 };
            RestaurantEvent re2 = new RestaurantEvent() { Name = "Restaurant Event 2", Description = "Restaurant Event 2 Description", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(4), Restaurant = r, EventTypes = let2 };
            RestaurantEvent re3 = new RestaurantEvent() { Name = "Restaurant Event 3", Description = "Restaurant Event 3 Description", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(4), Restaurant = r, EventTypes = let3 };
            RestaurantEvent re4 = new RestaurantEvent() { Name = "Restaurant Event 4", Description = "Restaurant Event 4 Description", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(4), Restaurant = r, EventTypes = let4 };
            RestaurantEvent re5 = new RestaurantEvent() { Name = "Restaurant Event 5", Description = "Restaurant Event 5 Description", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(4), Restaurant = r, EventTypes = let1 };


            context.RestaurantEvent.Add(re1);
            context.RestaurantEvent.Add(re2);
            context.RestaurantEvent.Add(re3);
            context.RestaurantEvent.Add(re4);
            context.RestaurantEvent.Add(re5);

            Cuisine cuisine1 = new Cuisine() { Name = "Cuisine 1" };
            Cuisine cuisine2 = new Cuisine() { Name = "Cuisine 2" };
            Cuisine cuisine3 = new Cuisine() { Name = "Cuisine 3" };
            Cuisine cuisine4 = new Cuisine() { Name = "Cuisine 4" };
            Cuisine cuisine5 = new Cuisine() { Name = "Cuisine 5" };
            Cuisine cuisine6 = new Cuisine() { Name = "Cuisine 6" };
            Cuisine cuisine7 = new Cuisine() { Name = "Cuisine 7" };
            context.Cuisines.Add(cuisine1);
            context.Cuisines.Add(cuisine2);
            context.Cuisines.Add(cuisine3);
            context.Cuisines.Add(cuisine4);
            context.Cuisines.Add(cuisine5);
            context.Cuisines.Add(cuisine6);
            context.Cuisines.Add(cuisine7);

             Meal ml1 = new Meal() { Name = "Meal 1", Description = "Meal 1 description", Price = 10, Cuisine = cuisine1 };
            Meal ml2 = new Meal() { Name = "Meal 2", Description = "Meal 2 description", Price = 10, Cuisine = cuisine2 };
            Meal ml3 = new Meal() { Name = "Meal 3", Description = "Meal 3 description", Price = 10, Cuisine = cuisine3 };
            Meal ml4 = new Meal() { Name = "Meal 4", Description = "Meal 4 description", Price = 10, Cuisine = cuisine4 };
            Meal ml5 = new Meal() { Name = "Meal 5", Description = "Meal 5 description", Price = 10, Cuisine = cuisine5 };
            Meal ml6 = new Meal() { Name = "Meal 6", Description = "Meal 6 description", Price = 10, Cuisine = cuisine6 };
            Meal ml7 = new Meal() { Name = "Meal 7", Description = "Meal 7 description", Price = 10, Cuisine = cuisine7 };

            Meal ml8 = new Meal() { Name = "Meal 8", Description = "Meal 8 description", Price = 10, Cuisine = cuisine1 };
            Meal ml9 = new Meal() { Name = "Meal 9", Description = "Meal 9 description", Price = 10, Cuisine = cuisine2 };
            Meal ml10 = new Meal() { Name = "Meal 10", Description = "Meal 10 description", Price = 10, Cuisine = cuisine3 };
            Meal ml11 = new Meal() { Name = "Meal 11", Description = "Meal 11 description", Price = 10, Cuisine = cuisine4 };
            Meal ml12 = new Meal() { Name = "Meal 12", Description = "Meal 12 description", Price = 10, Cuisine = cuisine5 };
            Meal ml13 = new Meal() { Name = "Meal 13", Description = "Meal 13 description", Price = 10, Cuisine = cuisine6 };
            Meal ml14 = new Meal() { Name = "Meal 14", Description = "Meal 14 description", Price = 10, Cuisine = cuisine7 };

            context.Meals.Add(ml1);
            context.Meals.Add(ml2);
            context.Meals.Add(ml3);
            context.Meals.Add(ml4);
            context.Meals.Add(ml5);
            context.Meals.Add(ml6);
            context.Meals.Add(ml7);
            context.Meals.Add(ml8);
            context.Meals.Add(ml9);
            context.Meals.Add(ml10);
            context.Meals.Add(ml11);
            context.Meals.Add(ml12);
            context.Meals.Add(ml13);
            context.Meals.Add(ml14);

            List<Meal> LML1 = new List<Meal>();
            LML1.Add(ml1);
            LML1.Add(ml7);
            LML1.Add(ml8);
            LML1.Add(ml14);

            List<Meal> LML2 = new List<Meal>();
            LML1.Add(ml2);
            LML1.Add(ml9);

            List<Meal> LML3 = new List<Meal>();
            LML1.Add(ml3);
            LML1.Add(ml10);

            List<Meal> LML4 = new List<Meal>();
            LML1.Add(ml4);
            LML1.Add(ml11);

            List<Meal> LML5 = new List<Meal>();
            LML1.Add(ml5);
            LML1.Add(ml12);

            List<Meal> LML6 = new List<Meal>();
            LML1.Add(ml6);
            LML1.Add(ml13);

            MealGroup mg1 = new MealGroup() { Name = "MealGroup 1", Meals = LML1 };
            MealGroup mg2 = new MealGroup() { Name = "MealGroup 2", Meals = LML2 };
            MealGroup mg3 = new MealGroup() { Name = "MealGroup 3", Meals = LML3 };
            MealGroup mg4 = new MealGroup() { Name = "MealGroup 4", Meals = LML4 };
            MealGroup mg5 = new MealGroup() { Name = "MealGroup 5", Meals = LML5 };
            MealGroup mg6 = new MealGroup() { Name = "MealGroup 6", Meals = LML6 };

            context.MealGroups.Add(mg1);
            context.MealGroups.Add(mg2);
            context.MealGroups.Add(mg3);
            context.MealGroups.Add(mg4);
            context.MealGroups.Add(mg5);
            context.MealGroups.Add(mg6);

            List<MealGroup> lgm1 = new List<MealGroup>();
            lgm1.Add(mg1);
            lgm1.Add(mg2);
            lgm1.Add(mg3);
            lgm1.Add(mg4);

            List<MealGroup> lgm2 = new List<MealGroup>();
            lgm2.Add(mg5);
            lgm2.Add(mg6);

            Menu M1 = new Menu() { Name = "Menu 1", MealGroups = lgm1, IsShow = true, Restaurant = r };
            Menu M2 = new Menu() { Name = "Menu 2", MealGroups = lgm2, IsShow = true, Restaurant = r };

            context.Menus.Add(M1);
            context.Menus.Add(M2);
            
            context.Restaurants.Add(r);
            context.SaveChanges();
        }

        private void InitializeAdminUserAndRoles(GoodTasteContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем роли
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