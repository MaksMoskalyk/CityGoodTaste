﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CityGoodTaste.Models
{
    public class GoodTasteDBInitializer :DropCreateDatabaseAlways<GoodTasteContext>
    {
        protected override void Seed(GoodTasteContext context)
        {
            InitializeAdminUserAndRoles(context);
            InitializeRestaurant(context);

            InitializeRestaurantAdministration(context);
            base.Seed(context);
        }


        private void InitializeRestaurant(GoodTasteContext context)
        {
            Country c = new Country { Name = "Украина" };
            City ct = new City { Name = "Одесса", Country = c };
            Neighborhood n1 = new Neighborhood { Name = "Киевский район" };
            Neighborhood n2 = new Neighborhood { Name = "Малиновский район" };
            Neighborhood n3 = new Neighborhood { Name = "Приморский район" };
            Neighborhood n4 = new Neighborhood { Name = "Суворовский район" };
            context.Neighborhoods.Add(n1);
            context.Neighborhoods.Add(n2);
            context.Neighborhoods.Add(n3);
            context.Neighborhoods.Add(n4);

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { Email = "somemail2@mail.ru", UserName = "user", Name="Артур" };
            var result = userManager.Create(user, "Password!2");
            var user2 = new ApplicationUser { Email = "somemail22@mail.ru", UserName = "user2", Name = "Виктор" };
            var result2 = userManager.Create(user2, "Password!2");
            var user3 = new ApplicationUser { Email = "somemail3@mail.ru", UserName = "user3", Name = "Светлана" };
            var result3 = userManager.Create(user3, "Password!2");
            Map map = new Map() { Latitude = 46.477055, Longitude = 30.725973, Zoom = 18 };
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Unit" };
            Restaurant r = new Restaurant
            {
                Name = "Unit",
                Address = "ул. Тираспольская, 22",
                ZipCode = 65000,
                AverageCheck = 205,
                Floors = 2,
                City=ct, 
                PhoneNumber="+380 48 729 9090",
                InformationAbout = "UNIT Military Cafe - это уникальное заведение c потрясающей кухней и удивительной атмосферой, выдержанное в военном стиле. Мы раскрываем военную тематику в оформлении, в подаче наших блюд и в мероприятиях. В нашем меню присутствуют блюда русской, украинской и немецкой кухни. Мы разнообразили её и легкими салатами, и сочными бургерами, различными закусками, и, конечно же, мясными блюдами, вкус которых по достоинству оценит любой гурман. Первый этаж сочетает комфортные столики и диваны с камуфляжной сеткой и различной армейской атрибутикой. На нижнем уровне перед Вами раскроются 3 VIP-зоны для командных сборов, брифингов и товарищеских посиделок: зал славы страйкбола, небольшой зал в приглушенных тонах с мягкими подушками.",
                 Map= map,
                 RestaurantGroup= restaurantsGroup,
                Neighborhood=n3
            };
            
            r.Photo = "/Img/UnitMain.jpg";
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
            RestaurantFeature f11 = new RestaurantFeature { Name = "Парковка" };
            RestaurantFeature f12 = new RestaurantFeature { Name = "Сезонное меню" };
            RestaurantFeature f13 = new RestaurantFeature { Name = "Летняя терраса" };
            RestaurantFeature f14 = new RestaurantFeature { Name = "Открытая кухня" };
            RestaurantFeature f15 = new RestaurantFeature { Name = "Оплата за обслуживание включена в чек" };
            RestaurantFeature f16 = new RestaurantFeature { Name = "Dj" };
            RestaurantFeature f17 = new RestaurantFeature { Name = "VIP зал" };
            RestaurantFeature f18 = new RestaurantFeature { Name = "Бесплатная вода от заведения" };
            RestaurantFeature f19 = new RestaurantFeature { Name = "Бильярд" };
            RestaurantFeature f20 = new RestaurantFeature { Name = "Зал для курящих" };
            RestaurantFeature f21 = new RestaurantFeature { Name = "Кальян" };
            RestaurantFeature f22 = new RestaurantFeature { Name = "Круглосуточный" };
            RestaurantFeature f23 = new RestaurantFeature { Name = "На воде" };
            RestaurantFeature f24 = new RestaurantFeature { Name = "На крыше" };
            RestaurantFeature f25 = new RestaurantFeature { Name = "Настольные игры" };
            RestaurantFeature f26 = new RestaurantFeature { Name = "Танцпол" };
            RestaurantFeature f27 = new RestaurantFeature { Name = "Этно ресторан" };
            RestaurantFeature f28 = new RestaurantFeature { Name = "Банкетный зал" };

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
            r.RestaurantFeatures.Add(f3);
            r.RestaurantFeatures.Add(f13);
            r.RestaurantFeatures.Add(f10);
            r.RestaurantFeatures.Add(f7);
            r.RestaurantFeatures.Add(f2);

           
            context.RestaurantFeatures.Add(f1);
            context.RestaurantFeatures.Add(f2);
            context.RestaurantFeatures.Add(f3);
            context.RestaurantFeatures.Add(f4);
            context.RestaurantFeatures.Add(f5);
            context.RestaurantFeatures.Add(f6);
            context.RestaurantFeatures.Add(f7);
            context.RestaurantFeatures.Add(f8);
            context.RestaurantFeatures.Add(f9);
            context.RestaurantFeatures.Add(f10);
            context.RestaurantFeatures.Add(f11);
            context.RestaurantFeatures.Add(f12);
            context.RestaurantFeatures.Add(f13);
            context.RestaurantFeatures.Add(f14);
            context.RestaurantFeatures.Add(f15);
            context.RestaurantFeatures.Add(f16);
            context.RestaurantFeatures.Add(f17);
            context.RestaurantFeatures.Add(f18);
            context.RestaurantFeatures.Add(f19);
            context.RestaurantFeatures.Add(f20);
            context.RestaurantFeatures.Add(f21);
            context.RestaurantFeatures.Add(f22);
            context.RestaurantFeatures.Add(f23);
            context.RestaurantFeatures.Add(f24);
            context.RestaurantFeatures.Add(f25);
            context.RestaurantFeatures.Add(f26);
            context.RestaurantFeatures.Add(f27);
            context.RestaurantFeatures.Add(f28);
            r.WorkHours = new List<WorkHour>();
            for (int i = 0; i < 7; i++)
            {
                WorkHour wh = new WorkHour { OpenHour = new System.TimeSpan(10, 0, 0), CloseHour = new System.TimeSpan(22, 0, 0) };
                r.WorkHours.Add(wh);
                context.WorkHours.Add(wh);
            }

            Like like = new Like { User = user, Restaurant = r };

            RestaurantSchema schema = new RestaurantSchema { Name = "Первый этаж", InDoor = true, Restaurant = r, SmokingZone = false, XLength = 22, YLength = 12 };
            Table t1 = new Table { Seats = 4, X = 1, Y = 1};
            Table t2 = new Table { Seats = 4, X = 1, Y = 3};
            Table t3 = new Table { Seats = 4, X = 1, Y = 5};
            Table t4 = new Table { Seats = 6, X = 3, Y = 1};
            Table t5 = new Table { Seats = 6, X = 3, Y = 3};
            Table t6 = new Table { Seats = 6, X = 3, Y = 5};
            Table t7 = new Table { Seats = 6, X = 2, Y = 7};
            Table t8 = new Table { Seats = 4, X = 2, Y = 9 };
            Table t9 = new Table { Seats = 4, X = 4, Y = 9 };
            Table t10 = new Table { Seats = 6, X = 3, Y = 11};
            Table t11 = new Table { Seats = 1, X = 6, Y = 5 };
            Table t12 = new Table { Seats = 1, X = 7, Y = 5 };
            Table t13 = new Table { Seats = 1, X = 8, Y = 5 };
            Table t14 = new Table { Seats = 1, X = 9, Y = 5 };
            Table t15 = new Table { Seats = 1, X = 10, Y = 5 };
            Table t16 = new Table { Seats = 1, X = 11, Y = 5 };
            Table t17 = new Table { Seats = 1, X = 12, Y = 5 };
            Table t18 = new Table { Seats = 1, X = 13, Y = 5 };
            Table t19 = new Table { Seats = 4, X = 9, Y = 9 };
            Table t20 = new Table { Seats = 6, X = 12, Y = 8 };
            Table t21 = new Table { Seats = 6, X = 12, Y = 10 };
            Table t22 = new Table { Seats = 4, X = 16, Y = 8 };
            Table t23 = new Table { Seats = 6, X = 16, Y = 10 };
            Table t24 = new Table { Seats = 4, X = 18, Y = 8 };
            Table t25 = new Table { Seats = 4, X = 18, Y = 10 };
            Table t26 = new Table { Seats = 4, X = 20, Y = 6 };
            Table t27 = new Table { Seats = 4, X = 17, Y = 6 };


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
            schema.Tables.Add(t19);
            schema.Tables.Add(t20);
            schema.Tables.Add(t21);
            schema.Tables.Add(t22);
            schema.Tables.Add(t23);
            schema.Tables.Add(t24);
            schema.Tables.Add(t25);
            schema.Tables.Add(t26);
            schema.Tables.Add(t27);

            context.RestaurantSchemas.Add(schema);

            context.Likes.Add(like);
            context.Countries.Add(c);
            context.Cities.Add(ct);

            EventType et1 =new EventType() { Name = "Quiz (викторина)" };
            EventType et2 = new EventType() { Name = "Живая музыка" };
            EventType et3 = new EventType() { Name = "Футбол" };
            EventType et4 = new EventType() { Name = "Новое меню" };
            EventType et5 = new EventType() { Name = "Octoberfest" };
            EventType et6 = new EventType() { Name = "Сезонное меню" };
            EventType et7 = new EventType() { Name = "Праздничное меню" };
            EventType et8 = new EventType() { Name = "Тематический вечер" };
            EventType et9 = new EventType() { Name = "Dj" };
            EventType et10 = new EventType() { Name = "Прочее" };
            EventType et11 = new EventType() { Name = "Скидка" };
            EventType et12 = new EventType() { Name = "Розыгрыш призов" };

            context.EventTypes.Add(et1);
            context.EventTypes.Add(et2);
            context.EventTypes.Add(et3);
            context.EventTypes.Add(et4);
            context.EventTypes.Add(et5);
            context.EventTypes.Add(et6);
            context.EventTypes.Add(et7);
            context.EventTypes.Add(et8);
            context.EventTypes.Add(et9);
            context.EventTypes.Add(et10);
            context.EventTypes.Add(et11);
            context.EventTypes.Add(et12);

            List<EventType> let1 = new List<EventType>();
            let1.Add(et2);

            List<EventType> let2 = new List<EventType>();
            let2.Add(et2);
            let2.Add(et10);
            List<EventType> let3 = new List<EventType>();
            let3.Add(et9);

            List<EventType> let4 = new List<EventType>();
            let4.Add(et4);

            
            RestaurantEvent re3 = new RestaurantEvent()
            {
                Name = "Old School Rock четверг с KIFA",
                Description = "Когда у человека есть вкус, есть чувство стиля, в народе все,что бы он не делал, называют \"фирмА\". Вкус и стиль потерять невозможно, это или есть, или нет. У Кифы есть всё, поэтому что бы она не делала: выбирала ли одежду, подбирала ли музыку, кушала ли или просто шла по улочкам Одессы- она делает это обворожительно и очень стильно. Вашему вниманию Acoustic Old School of Rock от удивительной группы KIFA!\n Проводите каждый четверг стильно и со вкусом!",
                StartDate = new DateTime(2017, 10, 27, 20, 0, 0),
                EndDate = new DateTime(2017, 10, 28, 0, 0, 0),
                Restaurant = r,
                EventTypes = let1,
                PhotoSmall = "/Img/Events/s_oldschoolrock.jpg",
                PhotoBig = "/Img/Events/b_oldschoolrock.jpg"
            };
            RestaurantEvent re4 = new RestaurantEvent()
            {
                Name = "GOLDWAY в UNIT Men's Cafe!",
                Description = "Вечеринка в UNIT Men’s Life CAFÉ с группой «GOLDWAY»."+
"\n«GOLDWAY» -молодой кавер - проект из города - героя Одессы. Группа была образована в мае 2016 года, в своём репертуаре имеет хиты супер - широкого спектра!" +
"\nОни готовы завести вас так, чтобы вы визжали и танцевали с нами, как будто любимый плей - лист приехал в ваш город)))" +
"\nВ программе вечера - Gotye, Bruno Mars, 30 Seconds To Mars, Coldplay, One Republic, Бумбокс и др. не менее известные кавера!",
                StartDate = new DateTime(2017, 10, 28, 20, 0, 0),
                EndDate = new DateTime(2017, 10, 29, 0, 0, 0),
                Restaurant = r,
                EventTypes = let2,
                PhotoSmall = "/Img/Events/s_goldway.jpg",
                PhotoBig = "/Img/Events/b_goldway.jpg"
            };
            RestaurantEvent re5 = new RestaurantEvent()
            {
                Name = "ПАТРОНИЧІ в UNIT Men's Life Cafe",
                Description = "Устали от рутины и серых будней? Тогда эта группа точно была создана для вас!)"+
"\nВ 2010 году ребята собрались для того, чтобы творить: творить музыку и беспредел!) Группа, которая поражает своей энергетикой и позитивом. Очаровательные улыбки, блестящие глаза и яркие эмоции -как раз то, чего так не хватает в наших хмурых буднях." +
"\n в UNIT будет по - настоящему весело!) Особенно потому, что группа приезжает с новым альбомом.Приходите оценить и расслабиться!) Почувствуйте энергию украинской музыки!",
                StartDate = new DateTime(2017, 10, 29, 20, 0, 0),
                EndDate = new DateTime(2017, 10, 30, 0, 0, 0),
                Restaurant = r,
                EventTypes = let3,
                PhotoSmall = "/Img/Events/s_patrochiny.jpg",
                PhotoBig = "/Img/Events/b_patrochiny.jpg"
            };
            context.RestaurantEvent.Add(re3);
            context.RestaurantEvent.Add(re4);
            context.RestaurantEvent.Add(re5);

            Cuisine cuisine1 = new Cuisine() { Name = "Авангардная" };
            Cuisine cuisine2 = new Cuisine() { Name = "Авторская" };
            Cuisine cuisine3 = new Cuisine() { Name = "Азербайджанская " };
            Cuisine cuisine4 = new Cuisine() { Name = "Азиатская" };
            Cuisine cuisine5 = new Cuisine() { Name = "Американская" };
            Cuisine cuisine6 = new Cuisine() { Name = "Английская" };
            Cuisine cuisine7 = new Cuisine() { Name = "Аргентинская" };
            Cuisine cuisine8 = new Cuisine() { Name = "Армянская" };
            Cuisine cuisine9 = new Cuisine() { Name = "Бельгийская" };
            Cuisine cuisine10 = new Cuisine() { Name = "Ближневосточная" };
            Cuisine cuisine11 = new Cuisine() { Name = "Бразильская" };
            Cuisine cuisine12 = new Cuisine() { Name = "Вегетарианская" };
            Cuisine cuisine13 = new Cuisine() { Name = "Венгерская" };
            Cuisine cuisine14 = new Cuisine() { Name = "Восточная" };
            Cuisine cuisine15 = new Cuisine() { Name = "Греческая" };
            Cuisine cuisine16 = new Cuisine() { Name = "Грузинская" };
            Cuisine cuisine17 = new Cuisine() { Name = "Домашняя" };
            Cuisine cuisine18 = new Cuisine() { Name = "Еврейская" };
            Cuisine cuisine19 = new Cuisine() { Name = "Европейская" };
            Cuisine cuisine20 = new Cuisine() { Name = "Индийская" };
            Cuisine cuisine21 = new Cuisine() { Name = "Интернациональная" };
            Cuisine cuisine22 = new Cuisine() { Name = "Ирландская" };
            Cuisine cuisine23 = new Cuisine() { Name = "Испанская" };
            Cuisine cuisine24 = new Cuisine() { Name = "Итальянская" };
            Cuisine cuisine26 = new Cuisine() { Name = "Кавказская" };
            Cuisine cuisine27 = new Cuisine() { Name = "Китайская" };
            Cuisine cuisine28 = new Cuisine() { Name = "Корейская" };
            Cuisine cuisine29 = new Cuisine() { Name = "Крымскотатарская " };
            Cuisine cuisine30 = new Cuisine() { Name = "Кубинская" };
            Cuisine cuisine31 = new Cuisine() { Name = "Ливанская" };
            Cuisine cuisine32 = new Cuisine() { Name = "Литовская" };
            Cuisine cuisine33 = new Cuisine() { Name = "Мексиканская" };
            Cuisine cuisine34 = new Cuisine() { Name = "Молекулярная" };
            Cuisine cuisine35 = new Cuisine() { Name = "Мясная" };
            Cuisine cuisine36 = new Cuisine() { Name = "Немецкая" };
            Cuisine cuisine37 = new Cuisine() { Name = "Паназиатская" };
            Cuisine cuisine38 = new Cuisine() { Name = "Персидская" };
            Cuisine cuisine39 = new Cuisine() { Name = "Перуанская" };
            Cuisine cuisine40 = new Cuisine() { Name = "Русская" };
            Cuisine cuisine41 = new Cuisine() { Name = "Сезонная" };
            Cuisine cuisine42 = new Cuisine() { Name = "Скандинавская" };
            Cuisine cuisine43 = new Cuisine() { Name = "Средиземноморская" };
            Cuisine cuisine44 = new Cuisine() { Name = "Старославянская" };
            Cuisine cuisine45 = new Cuisine() { Name = "Тайская" };
            Cuisine cuisine46 = new Cuisine() { Name = "Турецкая" };
            Cuisine cuisine47 = new Cuisine() { Name = "Узбекская" };
            Cuisine cuisine48 = new Cuisine() { Name = "Украинская" };
            Cuisine cuisine49 = new Cuisine() { Name = "Французская" };
            Cuisine cuisine50 = new Cuisine() { Name = "Фьюжн" };
            Cuisine cuisine51 = new Cuisine() { Name = "Чешская" };
            Cuisine cuisine52 = new Cuisine() { Name = "Шотландская" };
            Cuisine cuisine53 = new Cuisine() { Name = "Японская" };
            Cuisine cuisine54= new Cuisine() { Name = "Одесская" };
            
            context.Cuisines.Add(cuisine1);
            context.Cuisines.Add(cuisine2);
            context.Cuisines.Add(cuisine3);
            context.Cuisines.Add(cuisine4);
            context.Cuisines.Add(cuisine5);
            context.Cuisines.Add(cuisine6);
            context.Cuisines.Add(cuisine7);
            context.Cuisines.Add(cuisine8);
            context.Cuisines.Add(cuisine9);
            context.Cuisines.Add(cuisine10);
            context.Cuisines.Add(cuisine11);
            context.Cuisines.Add(cuisine12);
            context.Cuisines.Add(cuisine13);
            context.Cuisines.Add(cuisine14);
            context.Cuisines.Add(cuisine15);
            context.Cuisines.Add(cuisine16);
            context.Cuisines.Add(cuisine17);
            context.Cuisines.Add(cuisine18);
            context.Cuisines.Add(cuisine19);
            context.Cuisines.Add(cuisine20);
            context.Cuisines.Add(cuisine21);
            context.Cuisines.Add(cuisine22);
            context.Cuisines.Add(cuisine23);
            context.Cuisines.Add(cuisine24);
            context.Cuisines.Add(cuisine26);
            context.Cuisines.Add(cuisine27);
            context.Cuisines.Add(cuisine28);
            context.Cuisines.Add(cuisine29);
            context.Cuisines.Add(cuisine30);
            context.Cuisines.Add(cuisine31);
            context.Cuisines.Add(cuisine32);
            context.Cuisines.Add(cuisine33);
            context.Cuisines.Add(cuisine34);
            context.Cuisines.Add(cuisine35);
            context.Cuisines.Add(cuisine36);
            context.Cuisines.Add(cuisine54);
            context.Cuisines.Add(cuisine37);
            context.Cuisines.Add(cuisine38);
            context.Cuisines.Add(cuisine39);
            context.Cuisines.Add(cuisine40);
            context.Cuisines.Add(cuisine41);
            context.Cuisines.Add(cuisine42);
            context.Cuisines.Add(cuisine43);
            context.Cuisines.Add(cuisine44);
            context.Cuisines.Add(cuisine45);
            context.Cuisines.Add(cuisine46);
            context.Cuisines.Add(cuisine47);
            context.Cuisines.Add(cuisine48);
            context.Cuisines.Add(cuisine49);
            context.Cuisines.Add(cuisine50);
            context.Cuisines.Add(cuisine51);
            context.Cuisines.Add(cuisine52);
            context.Cuisines.Add(cuisine53);
            context.Cuisines.Add(cuisine54);
            r.Cuisines = new List<Cuisine>();
            r.Cuisines.Add(cuisine19);
            r.Cuisines.Add(cuisine36);
            r.Cuisines.Add(cuisine48);

            Currency crnc = new Currency() {Name= "Hryvnia", Sing= "₴" };

            Meal ml1 = new Meal()
            {
                Name = "Здоровый салат",
                Description = "свежие огурцы, томаты, капуста, оливковое масло.\n 250гр"
                ,
                Price = 55,
                Cuisine = cuisine1,
                Currency = crnc
            };
            Meal ml2 = new Meal()
            {
                Name = "Салат\"На зависть врагам\"",
                Description = "микс салатов, томаты, свежие огурцы, хрустящие сырные шарики, пряный кисло-сладкий соус.\n 200 гр."
                ,
                Price = 60,
                Cuisine = cuisine2,
                Currency = crnc
            };
            Meal ml3 = new Meal()
            {
                Name = "Знаменитый салат \"Юнит\"",
                Description = "балик, шампиьоны, свежие томаты, салатный лук, майонез, лаваш.\n 300 гр."
                ,
                Price = 65,
                Cuisine = cuisine3,
                Currency = crnc
            };
            Meal ml4 = new Meal()
            {
                Name = "Лучший салат",
                Description = "микс салатов, томаты, свежие огурцы, теплая сочна телятина, сырные шарики, пряный кислосладкий соус.\n 300 гр."
                ,
                Price = 80,
                Cuisine = cuisine4,
                Currency = crnc
            };
            Meal ml5 = new Meal()
            {
                Name = "Чемпионский салат",
                Description = "микс салатов, теплый картофель, сочная телятина, шампиньоны, пикантный имбирный соус.\n 260 гр."
                ,
                Price = 85,
                Cuisine = cuisine5,
                Currency = crnc
            };
            Meal ml6 = new Meal()
            {
                Name = "Волевая нарезка",
                Description = "помидоры, огурцы, перец болгарский, зелень.\n 350 гр."
                ,
                Price = 80,
                Cuisine = cuisine6,
                Currency = crnc
            };
            Meal ml7 = new Meal()
            {
                Name = "Практичный закусон",
                Description = "м/с огурцы, маринованные томаты, квашеная капуста, перец болгарский.\n 250 гр."
                ,
                Price = 45,
                Cuisine = cuisine7,
                Currency = crnc
            };

            Meal ml8 = new Meal()
            {
                Name = "Дисциплинированное сало",
                Description = "тонко нарезанное сало с хрустящими тостами - 4 вида засолки.\n 150/100 гр."
                ,
                Price = 55,
                Cuisine = cuisine1,
                Currency = crnc
            };
            Meal ml9 = new Meal()
            {
                Name = "Порядочная сельдь по-одесский",
                Description = "нежное филе сельди с печеным картофелем, маслинами, лимоном и маринованным луком.\n 300 гр."
                ,
                Price = 55,
                Cuisine = cuisine2,
                Currency = crnc
            };
            Meal ml10 = new Meal()
            {
                Name = "Терпеливые овощи хоспер",
                Description = "кабочки, баклажаны, перец болгарский, томаты, шампипьоны, соус тар-тар.\n 200/30 гр."
                ,
                Price = 80,
                Cuisine = cuisine3,
                Currency = crnc
            };
            Meal ml11 = new Meal()
            {
                Name = "Джентельменские шляпы",
                Description = "запеченные в хоспере шляпки шампиньонов,  фаршировананные сыром сулугуныи, подаються на лаваше и соусом тар-тар.\n 200/30 гр."
                ,
                Price = 60,
                Cuisine = cuisine4,
                Currency = crnc
            };
            Meal ml12 = new Meal()
            {
                Name = "Благородный лаваш",
                Description = "сулугуни с помидором и зеленью в лаваше, обжареный в хоспере.\n 250 гр."
                ,
                Price = 50,
                Cuisine = cuisine5,
                Currency = crnc
            };
            Meal ml13 = new Meal()
            {
                Name = "Честный маржской турнир",
                Description = "бруссочки твердого сыра в ххрустящей панировке,  падаються с ягодным соусом. 150/30 гр."
                ,
                Price = 55,
                Cuisine = cuisine6,
                Currency = crnc
            };
            Meal ml14 = new Meal()
            {
                Name = "Четкий куринный бургер",
                Description = "бургер с куриным филе хоспер, томатами, сыром, подпеться с картофилем фри, майонезом.\n 400 гр.",
                Price = 80,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml15 = new Meal()
            {
                Name = "Изобретательный чисбургер",
                Description = "бургер с сыром фри в панировке, с м/с огурцом, свежими томатами, подаеться с картофелем фри, соусом BBQ, майонезом.\n 400 гр.",
                Price = 80,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml16 = new Meal()
            {
                Name = "Пунктуальный бифбургер",
                Description = "бургер с сочным бифштексом из рубленого мяса, сыром и томатами, подаеться с картофелем фри и майонезом.\n 400 гр.",
                Price = 90,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml17 = new Meal()
            {
                Name = "Грамотный чиабатта с ветченой и сыром",
                Description = "чиабатта с ветченой, сыром и томатами, подаеться с печеным картофелем и кетчупом.\n 180/150/30 гр.",
                Price = 55,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml18 = new Meal()
            {
                Name = "Разумная овощная чиабатта",
                Description = "чиабатта с сыром, томатами и м/с огурцом, подаеться с печеным картофелем и кетчупом.\n 180/150/30 гр.",
                Price = 50,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml19 = new Meal()
            {
                Name = "Meal Универсальная сулугуни косичка",
                Description = "50 гр.",
                Price = 35,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml20 = new Meal()
            {
                Name = "Точные сырные палочки",
                Description = "хрустящие сырные палочки из слойки с кунжутом и морский солью.\n 100 гр.",
                Price = 35,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml21 = new Meal()
            {
                Name = "Отважный сухпаек",
                Description = "ржаные гренки с честноком и зеленью.\n 100 гр.",
                Price = 25,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml22 = new Meal()
            {
                Name = "Мясны палочки",
                Description = "50 гр.",
                Price = 40,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml23 = new Meal()
            {
                Name = "Справедливые трофеи",
                Description = "сырные палочки, мясные палочки, сулугуни косичка.\n 50/30/30 гр.",
                Price = 80,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml24 = new Meal()
            {
                Name = "Ловкие рисовые чипсы",
                Description = "подаються с соусом тар-тар.\n 40/30 гр.",
                Price = 25,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml25 = new Meal()
            {
                Name = "Бдительные свиние ушки",
                Description = "тонко нарезанные копченые свиные ушки, заправленые специями и честноком.\n 100 гр.",
                Price = 55,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml26 = new Meal()
            {
                Name = "Крепкие орешки",
                Description = "130 гр.",
                Price = 30,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml27 = new Meal()
            {
                Name = "Гениальный грбной суп-крем",
                Description = "сливочный суп-крем их шампиьонов с сыром пармезан, падаеться с сухариками.\n 250 гр.",
                Price = 40,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml28 = new Meal()
            {
                Name = "Борщ",
                Description = "традиционный украинский мясной борщ, подаеться с салом, сметаной и чесноком.\n 300 гр.",
                Price = 45,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml29 = new Meal()
            {
                Name = "Образцовый суп с фрикадельками",
                Description = "ароматный бульйон с куриными фрикадельками и картофелем.\n 300 гр.",
                Price = 40,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml30 = new Meal()
            {
                Name = "Проворная скумбрия",
                Description = "жаренная в хоспере, подаеться на лаваше, со свежими огурцами и соусом тар-тар.\n 300 гр.",
                Price = 100,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml31 = new Meal()
            {
                Name = "Пунктуальные драники",
                Description = "картофельные драники ссоусом из грибов, лука и сливок, подаеться со сметаной и зеленью.\n 200 гр.",
                Price = 50,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml32 = new Meal()
            {
                Name = "Авторитетное жаркое",
                Description = "сливочно-сырное жаркое с куриным окороком и шампиньенами, подаеться и запекаеться в горшочке.\n 350 гр.",
                Price = 70,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml33 = new Meal()
            {
                Name = "Дипломатичные вареники с картофелем",
                Description = "домашние вареники с картофелем, приготовлениые нашим поваром, подаеться с беконом, луком и сметаной.\n 250/30/30 гр.",
                Price = 55,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml34 = new Meal()
            {
                Name = "Ответстенные пелемени",
                Description = "домашние пельмени с укропом и сметаною.\n 250/30/30 гр.",
                Price = 65,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml35 = new Meal()
            {
                Name = "Дальновидные крылишки",
                Description = "обжарение и притушенные в остро-сладком соусе крылышки с кунжутом и печеным картофелем.\n 300/150 гр.",
                Price = 80,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml36 = new Meal()
            {
                Name = "Добросовестный бефстроганов",
                Description = "нежное филе телятины с грибами в сливочном соусе с картофельным пюре и м/с огурцами.\n 200/150 гр.",
                Price = 90,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml37 = new Meal()
            {
                Name = "С охочничьими колбасками",
                Description = "Охочничьи колбаски с картофелем по-домашнему и соусом BBQ.\n 350/30 гр.",
                Price = 70,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml38 = new Meal()
            {
                Name = "С куриными колбасками",
                Description = "Куриные колбаски с печеным картофелем, грибами соусом BBQ и горчицей.\n 300/60 гр.",
                Price = 90,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml39 = new Meal()
            {
                Name = "Картофель по-сельски",
                Description = ".\n 250 гр.",
                Price = 30,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml40 = new Meal()
            {
                Name = "Картофель фри",
                Description = "Картофель фри.\n 150 гр.",
                Price = 35,
                Cuisine = cuisine7,
                Currency = crnc
            };
            
            Meal ml43 = new Meal()
            {
                Name = "Vego-доска",
                Description = "Овощи гриль, печеный картофель, сулугуный и соус тар-тар.\n 1кг гр.",
                Price = 250,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml44 = new Meal()
            {
                Name = "Пивная доска",
                Description = "Сырные палочки, рисовые чипсы, копченый сулугуный, картофель фри, копченые свиные ушки.\n 550 гр.",
                Price = 230,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml41 = new Meal()
            {
                Name = "Доска шашлычный хоспер",
                Description = "Свиной, куриный шашлик, медальньрны из телятины со свежими офощами, картофелем по-сельки и соусом BBQ.\n 1кг/300 гр.",
                Price = 470,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml42 = new Meal()
            {
                Name = "Доска домашняя хоспер",
                Description = "Колбаски свинные и охотничьи, куриные крылышки, куриный окорок, печеный картофель с беконом и соусом BBQ.\n 1кг/250 гр.",
                Price = 450,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml45 = new Meal()
            {
                Name = "Мороженое",
                Description = "(в асортименте)\n 50 гр.",
                Price = 15,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml46 = new Meal()
            {
                Name = "Сырники",
                Description = "Домашнии пышные сырники, подаються со сметаной и ягодным соусом.\n 200 гр.",
                Price = 50,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml47 = new Meal()
            {
                Name = "Яблочный штрудель",
                Description = "(подаеться с шариком мороженого).\n 250/30 гр.",
                Price = 60,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml48 = new Meal()
            {
                Name = "Экспрессо",
                Description = "300 мл",
                Price = 20,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml49 = new Meal()
            {
                Name = "Американо",
                Description = "70 мл",
                Price = 20,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml50 = new Meal()
            {
                Name = "Капучино",
                Description = "100 мл",
                Price = 30,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml51 = new Meal()
            {
                Name = "Латте",
                Description = "200 мл",
                Price = 30,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml52 = new Meal()
            {
                Name = "Ромашковый",
                Description = "500 мл",
                Price = 35,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml53 = new Meal()
            {
                Name = "Ягодный",
                Description = "500 мл",
                Price = 35,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml54 = new Meal()
            {
                Name = "Облепиховый с имбирем",
                Description = "500 мл",
                Price = 40,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml55 = new Meal()
            {
                Name = "Цитрусово-мятный",
                Description = "500 мл",
                Price = 50,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml56 = new Meal()
            {
                Name = "Сок",
                Description = "(в асортименте)\n 250 мл",
                Price = 15,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml57 = new Meal()
            {
                Name = "Морс",
                Description = "(в асортименте)\n 250 мл",
                Price = 15,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml58 = new Meal()
            {
                Name = "Копмпот",
                Description = "(в асортименте)\n 250 мл",
                Price = 10,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml59 = new Meal()
            {
                Name = "Фреш",
                Description = "(в асортименте)\n 250 мл",
                Price = 70,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml60 = new Meal()
            {
                Name = "Лимонад",
                Description = "(в асортименте)\n 250 мл",
                Price = 25,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml61 = new Meal()
            {
                Name = "Ice tea",
                Description = "(в асортименте)\n 440 мл",
                Price = 30,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml62 = new Meal()
            {
                Name = "Молочный шейк",
                Description = "(в асортименте)\n 350 мл",
                Price = 60,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml63 = new Meal()
            {
                Name = "Мохито Б/А",
                Description = "(в асортименте)\n 440 мл",
                Price = 55,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml64 = new Meal()
            {
                Name = "Пиво разливное",
                Description = "(в асортименте)\n 500 мл",
                Price = 50,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml65 = new Meal()
            {
                Name = "Пиво бутылочное",
                Description = "(в асортименте)\n 500 мл",
                Price = 55,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml66 = new Meal()
            {
                Name = "Водка",
                Description = "(в асортименте)\n 50 мл",
                Price = 40,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml67 = new Meal()
            {
                Name = "Коньяк",
                Description = "(в асортименте)\n 50 мл",
                Price = 50,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml68 = new Meal()
            {
                Name = "Ром",
                Description = "(в асортименте)\n 50 мл",
                Price = 60,
                Cuisine = cuisine7,
                Currency = crnc
            };
            Meal ml69 = new Meal()
            {
                Name = "Текила",
                Description = "(в асортименте)\n 50 мл",
                Price = 55,
                Cuisine = cuisine7,
                Currency = crnc
            };
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
            context.Meals.Add(ml15);
            context.Meals.Add(ml16);
            context.Meals.Add(ml17);
            context.Meals.Add(ml18);
            context.Meals.Add(ml19);
            context.Meals.Add(ml20);
            context.Meals.Add(ml21);
            context.Meals.Add(ml22);
            context.Meals.Add(ml23);
            context.Meals.Add(ml24);
            context.Meals.Add(ml25);
            context.Meals.Add(ml26);
            context.Meals.Add(ml27);
            context.Meals.Add(ml28);
            context.Meals.Add(ml29);
            context.Meals.Add(ml30);
            context.Meals.Add(ml31);
            context.Meals.Add(ml32);
            context.Meals.Add(ml33);
            context.Meals.Add(ml34);
            context.Meals.Add(ml35);
            context.Meals.Add(ml36);
            context.Meals.Add(ml37);
            context.Meals.Add(ml38);
            context.Meals.Add(ml39);
            context.Meals.Add(ml40);
            context.Meals.Add(ml41);
            context.Meals.Add(ml42);
            context.Meals.Add(ml43);
            context.Meals.Add(ml44);
            context.Meals.Add(ml45);
            context.Meals.Add(ml46);
            context.Meals.Add(ml47);
            context.Meals.Add(ml48);
            context.Meals.Add(ml49);
            context.Meals.Add(ml50);
            context.Meals.Add(ml51);
            context.Meals.Add(ml52);
            context.Meals.Add(ml53);
            context.Meals.Add(ml54);
            context.Meals.Add(ml55);
            context.Meals.Add(ml56);
            context.Meals.Add(ml57);
            context.Meals.Add(ml58);
            context.Meals.Add(ml59);
            context.Meals.Add(ml60);
            context.Meals.Add(ml61);
            context.Meals.Add(ml62);
            context.Meals.Add(ml63);
            context.Meals.Add(ml64);
            context.Meals.Add(ml65);
            context.Meals.Add(ml66);
            context.Meals.Add(ml67);
            context.Meals.Add(ml68);
            context.Meals.Add(ml69);

            List<Meal> LML1 = new List<Meal>();
            LML1.Add(ml1);
            LML1.Add(ml2);
            LML1.Add(ml3);
            LML1.Add(ml4);
            LML1.Add(ml5);

            List<Meal> LML2 = new List<Meal>();
            LML2.Add(ml6);
            LML2.Add(ml7);
            LML2.Add(ml8);
            LML2.Add(ml9);
            List<Meal> LML3 = new List<Meal>();
            LML3.Add(ml10);
            LML3.Add(ml11);
            LML3.Add(ml12);
            LML3.Add(ml13);
            List<Meal> LML4 = new List<Meal>();
            LML4.Add(ml14);
            LML4.Add(ml15);
            LML4.Add(ml16);
            LML4.Add(ml17);
            LML4.Add(ml18);
            List<Meal> LML5 = new List<Meal>();
            LML5.Add(ml19);
            LML5.Add(ml20);
            LML5.Add(ml21);
            LML5.Add(ml22);
            LML5.Add(ml23);
            LML5.Add(ml24);
            LML5.Add(ml25);
            LML5.Add(ml26);
            List<Meal> LML6 = new List<Meal>();
            LML6.Add(ml27);
            LML6.Add(ml28);
            LML6.Add(ml29);
            List<Meal> LML7 = new List<Meal>();
            LML7.Add(ml30);

            List<Meal> LML8 = new List<Meal>();
            LML8.Add(ml31);
            LML8.Add(ml32);
            LML8.Add(ml33);
            LML8.Add(ml34);
            LML8.Add(ml35);
            LML8.Add(ml36);
            //Горячие сковородки
            List<Meal> LML9 = new List<Meal>();
            LML9.Add(ml37);
            LML9.Add(ml38);
            //Гарниры
            List<Meal> LML10 = new List<Meal>();
            LML10.Add(ml39);
            LML10.Add(ml40);
            //Хоспер/гриль/мангал/барбекю
            List<Meal> LML11 = new List<Meal>();
            LML11.Add(ml41);
            LML11.Add(ml42);
            //Доски
            List<Meal> LML12 = new List<Meal>();
            LML12.Add(ml43);
            LML12.Add(ml44);
            //Десерты
            List<Meal> LML13 = new List<Meal>();
            LML13.Add(ml45);
            LML13.Add(ml46);
            LML13.Add(ml47);
            //кофе
            List<Meal> LML14 = new List<Meal>();
            LML14.Add(ml48);
            LML14.Add(ml49);
            LML14.Add(ml50);
            LML14.Add(ml51);
            //чай
            List<Meal> LML15 = new List<Meal>();
            LML15.Add(ml52);
            LML15.Add(ml53);
            LML15.Add(ml54);
            LML15.Add(ml55);

            List<Meal> LML16 = new List<Meal>();
            LML16.Add(ml56);
            LML16.Add(ml57);
            LML16.Add(ml58);
            LML16.Add(ml59);

            List<Meal> LML17 = new List<Meal>();
            LML17.Add(ml60);
            LML17.Add(ml61);
            LML17.Add(ml62);
            LML17.Add(ml63);

            List<Meal> LML18 = new List<Meal>();
            LML18.Add(ml64);
            LML18.Add(ml65);
            LML18.Add(ml66);
            LML18.Add(ml67);
            LML18.Add(ml68);
            LML18.Add(ml69);
            /*
            List<Meal> LML19 = new List<Meal>();
            //LML1.Add(ml1);


            List<Meal> LML20 = new List<Meal>();
            //LML1.Add(ml1);


            List<Meal> LML21 = new List<Meal>();
            //LML1.Add(ml1);


            List<Meal> LML22 = new List<Meal>();
            //LML1.Add(ml1);


            List<Meal> LML23 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML24 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML25 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML26 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML27 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML28 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML29 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML30 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML31 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML32 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML33 = new List<Meal>();
            //LML1.Add(ml1);

            List<Meal> LML34= new List<Meal>();
            //LML1.Add(ml1);
            */



            MealGroup mg1 = new MealGroup() { Name = "Салаты", Meals = LML1 };
            MealGroup mg2 = new MealGroup() { Name = "Холодные закуски", Meals = LML2 };
            MealGroup mg3 = new MealGroup() { Name = "Горячие закуски", Meals = LML3 };
            MealGroup mg4 = new MealGroup() { Name = "Бургеры и чиабатта", Meals = LML4 };
            MealGroup mg5 = new MealGroup() { Name = "К пиву", Meals = LML5 };
            MealGroup mg6 = new MealGroup() { Name = "Первые блюда", Meals = LML6 };
            MealGroup mg7 = new MealGroup() { Name = "Рыбные блюда", Meals = LML7 };
            MealGroup mg8 = new MealGroup() { Name = "Горячие блюда", Meals = LML8 };
            MealGroup mg9 = new MealGroup() { Name = "Горячие сковородки", Meals = LML9 };
            MealGroup mg10 = new MealGroup() { Name = "Гарниры", Meals = LML10 };
            MealGroup mg11 = new MealGroup() { Name = "Хоспер/гриль/мангал/барбекю", Meals = LML11 };
            MealGroup mg12 = new MealGroup() { Name = "Доски", Meals = LML12 };
            MealGroup mg13 = new MealGroup() { Name = "Десерты", Meals = LML13 };
            MealGroup mg14 = new MealGroup() { Name = "Кофе", Meals = LML14 };
            MealGroup mg15 = new MealGroup() { Name = "Чай", Meals = LML15 };
            MealGroup mg16 = new MealGroup() { Name = "Холодные безалкогольные напитки", Meals = LML16 };
            MealGroup mg17 = new MealGroup() { Name = "Коктейли безалкогольные", Meals = LML17 };
            //
            MealGroup mg18 = new MealGroup() { Name = "алкогольные напитки", Meals = LML18 };
            /*MealGroup mg18 = new MealGroup() { Name = "Вино", Meals = LML18 };
            MealGroup mg19 = new MealGroup() { Name = "Игристые вина", Meals = LML19 };
            MealGroup mg20 = new MealGroup() { Name = "Вермуты", Meals = LML20 };
            MealGroup mg21 = new MealGroup() { Name = "Настойки и наливки", Meals = LML21 };
            MealGroup mg22 = new MealGroup() { Name = "Виски", Meals = LML22 };
            MealGroup mg23 = new MealGroup() { Name = "Ром", Meals = LML23 };
            MealGroup mg24 = new MealGroup() { Name = "Текила", Meals = LML24 };
            MealGroup mg25 = new MealGroup() { Name = "Джин", Meals = LML25 };
            MealGroup mg26 = new MealGroup() { Name = "Пиво", Meals = LML26 };
            MealGroup mg27 = new MealGroup() { Name = "Водка", Meals = LML27 };
            //MealGroup mg28 = new MealGroup() { Name = "Водка", Meals = LML28 };
            MealGroup mg29 = new MealGroup() { Name = "Коньяк", Meals = LML29 };
            MealGroup mg30 = new MealGroup() { Name = "Ликеры", Meals = LML30 };
            MealGroup mg31 = new MealGroup() { Name = "Шоты", Meals = LML31 };
            MealGroup mg32 = new MealGroup() { Name = "Лонгдринки", Meals = LML32 };
            MealGroup mg33 = new MealGroup() { Name = "Коктели", Meals = LML33 };
            MealGroup mg34 = new MealGroup() { Name = "Горячие алкогольные напитки", Meals = LML34 };*/


            context.MealGroups.Add(mg1);
            context.MealGroups.Add(mg2);
            context.MealGroups.Add(mg3);
            context.MealGroups.Add(mg4);
            context.MealGroups.Add(mg5);
            context.MealGroups.Add(mg6);
            context.MealGroups.Add(mg7);
            context.MealGroups.Add(mg8);
            context.MealGroups.Add(mg9);
            context.MealGroups.Add(mg10);
            context.MealGroups.Add(mg11);
            context.MealGroups.Add(mg12);
            context.MealGroups.Add(mg13);
            context.MealGroups.Add(mg14);
            context.MealGroups.Add(mg15);
            context.MealGroups.Add(mg16);
            context.MealGroups.Add(mg17);
            context.MealGroups.Add(mg18);
            /*context.MealGroups.Add(mg19);
            context.MealGroups.Add(mg20);
            context.MealGroups.Add(mg21);
            context.MealGroups.Add(mg22);
            context.MealGroups.Add(mg23);
            context.MealGroups.Add(mg24);
            context.MealGroups.Add(mg25);
            context.MealGroups.Add(mg26);
            context.MealGroups.Add(mg27);
            //context.MealGroups.Add(mg28);
            context.MealGroups.Add(mg29);
            context.MealGroups.Add(mg30);
            context.MealGroups.Add(mg31);
            context.MealGroups.Add(mg32);
            context.MealGroups.Add(mg33);
            context.MealGroups.Add(mg34);*/

            List<MealGroup> lgm1 = new List<MealGroup>();
            lgm1.Add(mg1);
            lgm1.Add(mg2);
            lgm1.Add(mg3);
            lgm1.Add(mg4);
            lgm1.Add(mg5);
            lgm1.Add(mg6);
            lgm1.Add(mg7);
            lgm1.Add(mg8);
            lgm1.Add(mg9);
            lgm1.Add(mg10);
            lgm1.Add(mg11);
            lgm1.Add(mg12);
            lgm1.Add(mg13);

            List<MealGroup> lgm2 = new List<MealGroup>();
            lgm2.Add(mg14);
            lgm2.Add(mg15);
            lgm2.Add(mg16);
            lgm2.Add(mg17);
            lgm2.Add(mg18);
           /* lgm2.Add(mg19);
            lgm2.Add(mg20);
            lgm2.Add(mg21);
            lgm2.Add(mg22);
            lgm2.Add(mg23);
            lgm2.Add(mg24);
            lgm2.Add(mg25);
            lgm2.Add(mg26);
            lgm2.Add(mg27);
            //lgm2.Add(mg28);
            lgm2.Add(mg29);
            lgm2.Add(mg30);
            lgm2.Add(mg31);
            lgm2.Add(mg32);
            lgm2.Add(mg33);
            lgm2.Add(mg34);*/

            Menu M1 = new Menu() { Name = "Основное", MealGroups = lgm1, IsShow = true, Restaurant = r };
            Menu M2 = new Menu() { Name = "Напитки", MealGroups = lgm2, IsShow = true, Restaurant = r };

            context.Menus.Add(M1);
            context.Menus.Add(M2);
            
            context.Restaurants.Add(r);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup1 = new RestaurantsGroup() { Name = "Olio pizza" };
            Restaurant r1 = new Restaurant
            {
                Name = "Olio pizza",
                Address = "ул. Гаванная, 7",
                ZipCode = 95009,
                AverageCheck = 200,
                Floors = 1,
                PhoneNumber = "+380 482 33 50 11",
                InformationAbout = "Olio — это сеть популярных итальянских ресторанов в городе Одесса с итальянской кухней и знаменитым итальянским гостеприимством. Olio pizza создана силами людей, которые основательно подошли к вопросу рождения этого проекта – это одесские рестораторы Виталий и Лина Имерцаки. Известные такими успешными проектами, как  почитаемый украинский ресторан «Куманець», основанный в 2001 году, стильный и современный ресторан «GluKoza» с европейской и азиатской кухней, сеть ресторанов  Olio и кафе с домашней одесской кухней  «Тёtя-Моtя». На сегодняшний день в городе Одесса работают уже три заведения сети Olio и «Дай Бог!», чтобы сеть развивалась не теряя качества, сноровки и своей привлекательности.",
                RestaurantGroup = restaurantsGroup1,
                Photo = "/Img/Olio.jpg"
            };
            //Итальянская https://oliopizza.com.ua/about/
            r1.RestaurantFeatures = new List<RestaurantFeature>();
            r1.RestaurantFeatures.Add(f1);
            r1.RestaurantFeatures.Add(f12);
            r1.RestaurantFeatures.Add(f13);
            r1.Cuisines = new List<Cuisine>();
            r1.Cuisines.Add(cuisine24);
            r1.Neighborhood = n3;

            context.Restaurants.Add(r1);
            context.SaveChanges();


            RestaurantsGroup restaurantsGroup11 = new RestaurantsGroup() { Name = "Бернардацци" };
            Restaurant r11 = new Restaurant
            {
                Name = "Бернардацци",
                Address = "ул. Бунина, 15",
                ZipCode = 95009,
                AverageCheck = 400,
                Floors = 2,
                PhoneNumber = "+380 67 000 2511",
                InformationAbout = "",
                Photo = "/Img/bernardaci.png",
                RestaurantGroup = restaurantsGroup11
            };
            //http://od.vgorode.ua/reference/kafe_bary_restorany/108917-bernardatstsy-restoran
            r11.RestaurantFeatures = new List<RestaurantFeature>();
            r11.RestaurantFeatures.Add(f1);
            r11.RestaurantFeatures.Add(f3);
            r11.RestaurantFeatures.Add(f21);
            r11.RestaurantFeatures.Add(f11);

            r11.Neighborhood = n3;
            r11.Cuisines = new List<Cuisine>();
            r11.Cuisines.Add(cuisine19);
            r11.Cuisines.Add(cuisine53);
            r11.Cuisines.Add(cuisine54);
            r11.Cuisines.Add(cuisine43);
            context.Restaurants.Add(r11);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup2 = new RestaurantsGroup() { Name = "Pomodoro" };
            Restaurant r2 = new Restaurant
            {
                Name = "Pomodoro",
                Address = "Акад. Глушко проспект, 14/7",
                ZipCode = 95009,
                AverageCheck = 150,
                Floors = 2,
                PhoneNumber = "+380 48 700 0022",
                InformationAbout = "",
                RestaurantGroup = restaurantsGroup2,
                Photo = "/Img/pomadoro.png"
            };
            //http://pomodoro.od.ua/restaurant/1
            r2.RestaurantFeatures = new List<RestaurantFeature>();
            r2.RestaurantFeatures.Add(f1);
            r11.RestaurantFeatures.Add(f3);
            r11.RestaurantFeatures.Add(f21);
            r11.RestaurantFeatures.Add(f11);
            r11.RestaurantFeatures.Add(f14);
            r2.Cuisines = new List<Cuisine>();
            r2.Cuisines.Add(cuisine24);
            r2.Cuisines.Add(cuisine18);
            
            r2.Neighborhood = n1;

            context.Restaurants.Add(r2);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup3 = new RestaurantsGroup() { Name = "Бодега 2 Карла" };
            Restaurant r3 = new Restaurant
            {
                Name = "Бодега 2 Карла",
                Address = "ул. Греческая, 32",
                ZipCode = 95009,
                AverageCheck = 250,
                Floors = 1,
                PhoneNumber = "+380 96 524 1601",
                InformationAbout = "",
                RestaurantGroup = restaurantsGroup3,
                Photo = "/Img/2karla.png"
            };
            //http://eatsmart.ua/odessa/restoran/5978-Bodega-2Karla
            r3.RestaurantFeatures = new List<RestaurantFeature>();
            r3.RestaurantFeatures.Add(f1);
            r3.RestaurantFeatures.Add(f2);
            r3.RestaurantFeatures.Add(f3);
            r3.RestaurantFeatures.Add(f5);
            r3.RestaurantFeatures.Add(f25);
            r3.RestaurantFeatures.Add(f10);
            r3.Cuisines = new List<Cuisine>();
            r3.Cuisines.Add(cuisine26);
            r3.Cuisines.Add(cuisine26);
            r3.Neighborhood = n3;
            context.Restaurants.Add(r3);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup4 = new RestaurantsGroup() { Name = "Jardin" };
            Restaurant r4 = new Restaurant
            {
                Name = "Jardin",
                Address = "ул. Гаванная, 10",
                ZipCode = 95009,
                AverageCheck = 300,
                Floors = 1,
                PhoneNumber = "+380 48 700 14 71",
                InformationAbout = "",
                RestaurantGroup = restaurantsGroup4,
                Photo = "/Img/jardin.png"
            };
            //https://www.tripadvisor.ru/Restaurant_Review-g295368-d3329997-Reviews-Jardin-Odessa_Odessa_Oblast.html
            //http://topclub.ua/odessa/restaurant/jardin-gavanaya.html
            r4.RestaurantFeatures = new List<RestaurantFeature>();
            r4.RestaurantFeatures.Add(f1);
            r4.RestaurantFeatures.Add(f2);
            r4.RestaurantFeatures.Add(f10);
            r4.RestaurantFeatures.Add(f13);
            r4.RestaurantFeatures.Add(f12);
            r4.RestaurantFeatures.Add(f28);
            
            r4.Cuisines = new List<Cuisine>();
            r4.Cuisines.Add(cuisine24);
            r4.Cuisines.Add(cuisine49);
            r4.Neighborhood = n3;
            context.Restaurants.Add(r4);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup5 = new RestaurantsGroup() { Name = "Стейкхаус" };
            Restaurant r5 = new Restaurant
            {
                Name = "Стейкхаус",
                Address = "ул. Дерибасовская, 20",
                ZipCode = 65026,
                AverageCheck = 250,
                Floors = 1,
                PhoneNumber = "+380 482 348 782",
                InformationAbout = "",
                RestaurantGroup = restaurantsGroup5,
                Photo = "/Img/sh.jpg"
            };
            //http://topclub.ua/odessa/restaurant/stejkhaus_myaso_i_vino.html
            r5.RestaurantFeatures = new List<RestaurantFeature>();
            r5.RestaurantFeatures.Add(f1);
            r5.RestaurantFeatures.Add(f10);
            r5.RestaurantFeatures.Add(f13);

            r5.Cuisines = new List<Cuisine>();
            r5.Cuisines.Add(cuisine5);
            r5.Cuisines.Add(cuisine19);
            r5.Neighborhood = n3;

            context.Restaurants.Add(r5);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup6 = new RestaurantsGroup() { Name = "Тавернетта" };
            Restaurant r6 = new Restaurant
            {
                Name = "Тавернетта",
                Address = "ул. Екатерининская, 45",
                ZipCode = 95003,
                AverageCheck = 300,
                Floors = 1,
                PhoneNumber = "+380 96 234 4621",
                InformationAbout = "",
                RestaurantGroup = restaurantsGroup6,
                Photo = "/Img/tav.png"
            };
            //https://2gis.ua/odessa/firm/1970853118469591?queryState=center%2F30.738072%2C46.457635%2Fzoom%2F17
            r6.RestaurantFeatures = new List<RestaurantFeature>();
            r6.RestaurantFeatures.Add(f1);
            r6.RestaurantFeatures.Add(f2);
            r6.RestaurantFeatures.Add(f13);
            r6.RestaurantFeatures.Add(f10);
            r6.RestaurantFeatures.Add(f28);
            r6.RestaurantFeatures.Add(f8);
            r6.Cuisines = new List<Cuisine>();
            r6.Cuisines.Add(cuisine19);
            r6.Neighborhood = n3;
            context.Restaurants.Add(r6);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup7 = new RestaurantsGroup() { Name = "Фрателли" };
            Restaurant r7 = new Restaurant
            {
                Name = "Фрателли",
                Address = "ул. Греческая, 17",
                ZipCode = 65026,
                AverageCheck = 150,
                Floors = 1,
                PhoneNumber = "+380 48 738 4848",
                InformationAbout = "",
                RestaurantGroup = restaurantsGroup7,
                Photo = "/Img/frat.png"
            };
            //http://topclub.ua/odessa/restaurant/fratelli.html
            r7.RestaurantFeatures = new List<RestaurantFeature>();
            r7.RestaurantFeatures.Add(f1);
            r7.RestaurantFeatures.Add(f6);
            r7.RestaurantFeatures.Add(f13);
            r7.RestaurantFeatures.Add(f10);
            r7.RestaurantFeatures.Add(f8);
            r7.RestaurantFeatures.Add(f28);
            r7.RestaurantFeatures.Add(f20);
            r7.Cuisines = new List<Cuisine>();
            r7.Cuisines.Add(cuisine24);
            r7.Cuisines.Add(cuisine43);
            r7.Neighborhood = n3;

            context.Restaurants.Add(r7);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup8 = new RestaurantsGroup() { Name = "Дача" };
            Restaurant r8 = new Restaurant
            {
                Name = "Дача",
                Address = "Французский бульвар, 85/3",
                ZipCode = 65058,
                AverageCheck = 235,
                Floors = 1,
                PhoneNumber = "+380 48 714 3119",
                InformationAbout = "",
                RestaurantGroup = restaurantsGroup8,
                Photo = "/Img/dach.png"
            };

            //http://od.vgorode.ua/reference/restorany/100451-dacha

            r8.RestaurantFeatures = new List<RestaurantFeature>();
            r8.RestaurantFeatures.Add(f1);
            r8.RestaurantFeatures.Add(f27);
            r8.RestaurantFeatures.Add(f8);
            r8.RestaurantFeatures.Add(f12);
            r8.RestaurantFeatures.Add(f13);
            r8.RestaurantFeatures.Add(f10);
            r8.Cuisines = new List<Cuisine>();
            r8.Cuisines.Add(cuisine54);
            r8.Neighborhood = n3;
            context.Restaurants.Add(r8);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup9 = new RestaurantsGroup() { Name = "Grand Prix" };
            Restaurant r9 = new Restaurant
            {
                Name = "Grand Prix",
                Address = "ул. Бунина, 24",
                ZipCode = 65026,
                AverageCheck = 350,
                Floors = 2,
                PhoneNumber = "+380 48 785 0701",
                InformationAbout = "",
                RestaurantGroup = restaurantsGroup9,
                Photo = "/Img/grand.png"
            };
            //http://topclub.ua/odessa/restaurant/grand-prix.html
            r9.RestaurantFeatures = new List<RestaurantFeature>();
            r9.RestaurantFeatures.Add(f1);
            r9.RestaurantFeatures.Add(f28);
            r9.RestaurantFeatures.Add(f10);
            r9.Cuisines = new List<Cuisine>();
            r9.Cuisines.Add(cuisine19);
            r9.Neighborhood = n3;

            context.Restaurants.Add(r9);
            context.SaveChanges();

            RestaurantsGroup restaurantsGroup10 = new RestaurantsGroup() { Name = "Баффало 99" };
            Restaurant r10 = new Restaurant
            {
                Name = "Баффало 99",
                Address = "ул. Ришельевская, 7",
                ZipCode = 65014,
                AverageCheck = 300,
                Floors = 1,
                PhoneNumber = "+380 67 489 8395",
                InformationAbout = "",
                RestaurantGroup = restaurantsGroup10,
                Photo = "/Img/buf.png"
            };
            //https://www.tripadvisor.ru/Restaurant_Review-g295368-d4469988-Reviews-Buffalo_99-Odessa_Odessa_Oblast.html
            r10.RestaurantFeatures = new List<RestaurantFeature>();
            r10.RestaurantFeatures.Add(f1);
            r10.RestaurantFeatures.Add(f10);
            r10.RestaurantFeatures.Add(f13);

            r10.Cuisines = new List<Cuisine>();
            r10.Cuisines.Add(cuisine5);
            r10.Cuisines.Add(cuisine19);
            r10.Neighborhood = n3;

            context.Restaurants.Add(r10);
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

        private void InitializeRestaurantAdministration(GoodTasteContext context)
        {
            var rest = context.Restaurants.Where(x => x.Name == "Unit").FirstOrDefault();
            var user = context.Users.Where(x => x.UserName == "admin").FirstOrDefault();
            Administration administration = new Administration();
            administration.Restaurants = new List<Restaurant>();
            administration.Admins = new List<ApplicationUser>();
            administration.Restaurants.Add(rest);
            administration.Admins.Add(user);
            context.Administrations.Add(administration);
            context.SaveChanges();
        }
    }
}