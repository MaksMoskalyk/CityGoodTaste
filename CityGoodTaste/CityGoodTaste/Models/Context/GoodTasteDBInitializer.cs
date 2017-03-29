using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Collections.Generic;
using System;

namespace CityGoodTaste.Models
{
    public class GoodTasteDBInitializer :DropCreateDatabaseAlways<GoodTasteContext>
    {
        protected override void Seed(GoodTasteContext context)
        {
            InitializeAdminUserAndRoles(context);
            InitializeRestaurant(context);
            InitializeR1(context);
            InitializeR11(context);
            InitializeR2(context);
            InitializeR3(context);
            InitializeR4(context);
            InitializeR5(context);
            InitializeR6(context);
            InitializeR7(context);
            InitializeR8(context);
            InitializeR9(context);
            InitializeR10(context);
            base.Seed(context);
        }


        private void InitializeRestaurant(GoodTasteContext context)
        {
            Country c = new Country { Name = "Украина" };
            City ct = new City { Name = "Одесса", Country = c };
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser { Email = "somemail2@mail.ru", UserName = "user", Name="Артур" };
            var result = userManager.Create(user, "Password!2");
            var user2 = new ApplicationUser { Email = "somemail22@mail.ru", UserName = "user2", Name = "Виктор" };
            var result2 = userManager.Create(user2, "Password!2");
            var user3 = new ApplicationUser { Email = "somemail3@mail.ru", UserName = "user3", Name = "Светлана" };
            var result3 = userManager.Create(user3, "Password!2");
            Map map = new Map() { Latitude = 0, Longitude = 0, Zoom = 1 };
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Три Резвых Коня" };
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
                 RestaurantGroup= restaurantsGroup
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
            RestaurantFeature f15 = new RestaurantFeature { Name = "Оплата за обслужывание включена в чек" };
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
            r.RestaurantFeatures.Add(f11);
            r.RestaurantFeatures.Add(f12);
            r.RestaurantFeatures.Add(f13);
            r.RestaurantFeatures.Add(f14);
            r.RestaurantFeatures.Add(f15);
            r.RestaurantFeatures.Add(f16);
            r.RestaurantFeatures.Add(f17);
            r.RestaurantFeatures.Add(f18);
            r.RestaurantFeatures.Add(f19);
            r.RestaurantFeatures.Add(f20);
            r.RestaurantFeatures.Add(f21);
            r.RestaurantFeatures.Add(f22);
            r.RestaurantFeatures.Add(f23);
            r.RestaurantFeatures.Add(f24);
            r.RestaurantFeatures.Add(f25);
            r.RestaurantFeatures.Add(f26);
            r.RestaurantFeatures.Add(f27);
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
            //schema.Tables.Add(t28);

            context.RestaurantSchemas.Add(schema);

            context.Likes.Add(like);
            context.Countries.Add(c);
            context.Cities.Add(ct);

            EventType et1 =new EventType() { Name = "Quiz (викторина)" };
            EventType et2 = new EventType() { Name = "Живая музыка" };
            EventType et3 = new EventType() { Name = "Футбол" };
            EventType et4 = new EventType() { Name = "Новое маню" };

            context.EventTypes.Add(et1);
            context.EventTypes.Add(et2);
            context.EventTypes.Add(et3);
            context.EventTypes.Add(et4);

            List<EventType> let1 = new List<EventType>();
            let1.Add(et1);

            List<EventType> let2 = new List<EventType>();
            let2.Add(et2);

            List<EventType> let3 = new List<EventType>();
            let3.Add(et3);

            List<EventType> let4 = new List<EventType>();
            let4.Add(et4);

            RestaurantEvent re1 = new RestaurantEvent() { Name= "Wednesday Pub Quiz",Description= "Паб-квиз — от английских слов Pub (паб, тут все понятно) и Quiz (викторина). Это популярная во всём мире командная игра, которая объединяет в себе облегченные «Брейн-Ринг» или «Что? Где?Когда?» и веселое времяпрепровождение в пабе с друзьями. Мы приглашаем команды от 2х до 4х человек. Короче говоря, собираемся вместе, делимся на команды и весело проводим время, умничая и отвечая на вопросы.", StartDate= DateTime.Now , EndDate= DateTime.Now.AddHours(4) , Restaurant = r, EventTypes= let1, Photo="/Img/Events/1.jpg" };
            RestaurantEvent re2 = new RestaurantEvent() { Name = "Old School Rock четверг с KIFA", Description = "Когда у человека есть вкус, есть чувство стиля, в народе все,что бы он не делал, называют \"фирмА\". Вкус и стиль потерять невозможно, это или есть, или нет. У Кифы есть всё, поэтому что бы она не делала: выбирала ли одежду, подбирала ли музыку, кушала ли или просто шла по улочкам Одессы- она делает это обворожительно и очень стильно. Вашему вниманию Acoustic Old School of Rock от удивительной группы KIFA!", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(4), Restaurant = r, EventTypes = let2, Photo = "/Img/Events/2.jpg" };
            RestaurantEvent re3 = new RestaurantEvent() { Name = "Трансляция матча Хорватия-Украина", Description = "Трансляция матча Хорватия-Украина", StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(4), Restaurant = r, EventTypes = let3, Photo = "/Img/Events/3.jpg" };



            context.RestaurantEvent.Add(re1);
            context.RestaurantEvent.Add(re2);
            context.RestaurantEvent.Add(re3);


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
            Currency crnc = new Currency() {Name= "Hryvnia", sing= "₴" };

            Meal ml1 = new Meal() { Name = "Meal 1", Description = "Meal 1 description", Price = 10, Cuisine = cuisine1, Currency= crnc };
            Meal ml2 = new Meal() { Name = "Meal 2", Description = "Meal 2 description", Price = 10, Cuisine = cuisine2, Currency = crnc };
            Meal ml3 = new Meal() { Name = "Meal 3", Description = "Meal 3 description", Price = 10, Cuisine = cuisine3, Currency = crnc };
            Meal ml4 = new Meal() { Name = "Meal 4", Description = "Meal 4 description", Price = 10, Cuisine = cuisine4, Currency = crnc };
            Meal ml5 = new Meal() { Name = "Meal 5", Description = "Meal 5 description", Price = 10, Cuisine = cuisine5, Currency = crnc };
            Meal ml6 = new Meal() { Name = "Meal 6", Description = "Meal 6 description", Price = 10, Cuisine = cuisine6, Currency = crnc };
            Meal ml7 = new Meal() { Name = "Meal 7", Description = "Meal 7 description", Price = 10, Cuisine = cuisine7, Currency = crnc };

            Meal ml8 = new Meal() { Name = "Meal 8", Description = "Meal 8 description", Price = 10, Cuisine = cuisine1, Currency = crnc };
            Meal ml9 = new Meal() { Name = "Meal 9", Description = "Meal 9 description", Price = 10, Cuisine = cuisine2, Currency = crnc };
            Meal ml10 = new Meal() { Name = "Meal 10", Description = "Meal 10 description", Price = 10, Cuisine = cuisine3, Currency = crnc };
            Meal ml11 = new Meal() { Name = "Meal 11", Description = "Meal 11 description", Price = 10, Cuisine = cuisine4, Currency = crnc };
            Meal ml12 = new Meal() { Name = "Meal 12", Description = "Meal 12 description", Price = 10, Cuisine = cuisine5, Currency = crnc };
            Meal ml13 = new Meal() { Name = "Meal 13", Description = "Meal 13 description", Price = 10, Cuisine = cuisine6, Currency = crnc };
            Meal ml14 = new Meal() { Name = "Meal 14", Description = "Meal 14 description", Price = 10, Cuisine = cuisine7, Currency = crnc };

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
            LML2.Add(ml2);
            LML2.Add(ml9);

            List<Meal> LML3 = new List<Meal>();
            LML3.Add(ml3);
            LML3.Add(ml10);

            List<Meal> LML4 = new List<Meal>();
            LML4.Add(ml4);
            LML4.Add(ml11);

            List<Meal> LML5 = new List<Meal>();
            LML5.Add(ml5);
            LML5.Add(ml12);

            List<Meal> LML6 = new List<Meal>();
            LML6.Add(ml6);
            LML6.Add(ml13);

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
        private void InitializeR1(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Клён кудрявый" };
            Restaurant r = new Restaurant
            {
                Name = "Клён кудрявый",
                Address = "ул. Победы 16",
                ZipCode = 95009,
                AverageCheck = 150,
                Floors = 1,
                PhoneNumber = "+380 50 113 50 11",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(1));

            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR11(GoodTasteContext context)
        {
            
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Три Резвых Коня" };
            Restaurant r = new Restaurant
            {
                Name = "Три Резвых Коня",
                Address = "ул. Победы 6",
                ZipCode = 95009,
                AverageCheck = 305,
                Floors = 2,
                PhoneNumber = "+380 97 725 83 65",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                Photo = "/Img/food.png",
                RestaurantGroup = restaurantsGroup
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(2));

            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR2(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Винная идиллия" };
            Restaurant r = new Restaurant
            {
                Name = "Винная идилия",
                Address = "ул. краснова 99",
                ZipCode = 95009,
                AverageCheck = 310,
                Floors = 1,
                PhoneNumber = "+380 60 453 56 12",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(2));



            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR3(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Сладкоежкин" };
            Restaurant r = new Restaurant
            {
                Name = "Сладкоежкин",
                Address = "ул. Победы 16",
                ZipCode = 95009,
                AverageCheck = 150,
                Floors = 1,
                PhoneNumber = "+380 50 113 50 11",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(1));
            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR4(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Мир деликатесов" };
            Restaurant r = new Restaurant
            {
                Name = "Мир деликатесов",
                Address = "ул. Заболотного 33",
                ZipCode = 95009,
                AverageCheck = 180,
                Floors = 1,
                PhoneNumber = "+380 50 338 50 11",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(1));
            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR5(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Дом вкусняшек" };
            Restaurant r = new Restaurant
            {
                Name = "Дом вкусняшек",
                Address = "ул. Говорового 70",
                ZipCode = 95009,
                AverageCheck = 250,
                Floors = 1,
                PhoneNumber = "+380 67 241 67 11",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(1));
            
            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR6(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Ням-ням" };
            Restaurant r = new Restaurant
            {
                Name = "Ням-ням",
                Address = "ул. Болгарская 10",
                ZipCode = 95009,
                AverageCheck = 150,
                Floors = 1,
                PhoneNumber = "+380 90 555 60 11",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR7(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Море пива" };
            Restaurant r = new Restaurant
            {
                Name = "Море пива",
                Address = "ул. Победы 16",
                ZipCode = 95009,
                AverageCheck = 150,
                Floors = 1,
                PhoneNumber = "+380 50 890 23 56",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(1));

            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR8(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Фреш мит" };
            Restaurant r = new Restaurant
            {
                Name = "Фреш мит",
                Address = "ул. Старосенная 57",
                ZipCode = 95009,
                AverageCheck = 235,
                Floors = 1,
                PhoneNumber = "+380 50 546 23 67",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(1));

            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR9(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Гамбургеры и фри" };
            Restaurant r = new Restaurant
            {
                Name = "Гамбургеры и фри",
                Address = "ул. Ученическая 34",
                ZipCode = 95009,
                AverageCheck = 150,
                Floors = 1,
                PhoneNumber = "+380 50 123 12 43",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(1));

            context.Restaurants.Add(r);
            context.SaveChanges();
        }
        private void InitializeR10(GoodTasteContext context)
        {
            RestaurantsGroup restaurantsGroup = new RestaurantsGroup() { Name = "Фазаны и куропатки" };
            Restaurant r = new Restaurant
            {
                Name = "Фазаны и куропатки",
                Address = "ул. Кордонная 54",
                ZipCode = 95009,
                AverageCheck = 210,
                Floors = 1,
                PhoneNumber = "+380 90 789 34 56",
                InformationAbout = "Мы любим готовить! И самое главное для нас – чтобы вы готовили и получали от этого удовольствие!\n\r" +
                                    " Ну а мы со своей стороны предоставим все необходимое: большую кухню, удобные столы, качественную" +
                                    " технику и самые лучшие продукты! И, само собой, пригласим лучших шеф-поваров. Как и в обычной школе," +
                                    " у нас есть четкое разделение по предметам. Так, мы предлагаем классы итальянской, французской," +
                                    " кавказской, азиатской кухни и т.д.\n\r По желанию, можно посетить один понравившийся мастер-класс" +
                                    " или же пройти курс полностью. Кто к нам приходит? Мы рады всем! Студентам, безнесменам," +
                                    " домохозяйкам, белым воротничкам и даже тем, кто просто проходил мимо. Интересно будет каждому!" +
                                    "Как записаться? Расписание всех наших классов – на сайте, на страницах в Facebook!" +
                                    "У нас как в театре: хотите на класс – покупайте билет!",
                RestaurantGroup = restaurantsGroup,
                Photo = "/Img/food.png"
            };

            r.RestaurantFeatures = new List<RestaurantFeature>();
            r.RestaurantFeatures.Add(context.RestaurantFeatures.Find(1));


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