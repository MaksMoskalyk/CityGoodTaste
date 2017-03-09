﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CityGoodTaste
{
    public class GoodTasteContext : IdentityDbContext<ApplicationUser>
    {
        public GoodTasteContext() : base("GoodTasteContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new GoodTasteDBInitializer());
        }

        public static GoodTasteContext Create()
        {
            return new GoodTasteContext();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealGroup> MealGroups { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RestaurantEvent> rest_Events { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantFeature> RestaurantFeatures { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }
        public DbSet<RestaurantSchema> RestaurantSchemas { get; set; }
        public DbSet<RestaurantsGroup> RestaurantsGroups { get; set; }
        public DbSet<SpecialWorkHour> SpecialWorkHours { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }
    }
}