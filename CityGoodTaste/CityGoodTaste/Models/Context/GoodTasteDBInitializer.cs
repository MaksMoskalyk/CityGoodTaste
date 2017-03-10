using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using CityGoodTaste.Models;

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
                City=ct
            };
            Like like = new Like { User = user, Restaurant = r };
            context.Likes.Add(like);
            context.Countries.Add(c);
            context.Cities.Add(ct);
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