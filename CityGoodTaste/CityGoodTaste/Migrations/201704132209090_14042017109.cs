namespace CityGoodTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14042017109 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Photo = c.Binary(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Administration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrations", t => t.Administration_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Administration_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.Int(nullable: false),
                        PhoneNumber = c.String(maxLength: 25),
                        AverageCheck = c.Int(nullable: false),
                        InformationAbout = c.String(storeType: "ntext"),
                        Photo = c.String(),
                        Floors = c.Int(nullable: false),
                        Administration_Id = c.Int(),
                        Neighborhood_Id = c.Int(),
                        City_Id = c.Int(),
                        Map_id = c.Int(),
                        RestaurantGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrations", t => t.Administration_Id)
                .ForeignKey("dbo.Neighborhoods", t => t.Neighborhood_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Maps", t => t.Map_id)
                .ForeignKey("dbo.RestaurantsGroups", t => t.RestaurantGroup_Id)
                .Index(t => t.Administration_Id)
                .Index(t => t.Neighborhood_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Map_id)
                .Index(t => t.RestaurantGroup_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Neighborhoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Restaurant_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Zoom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsShow = c.Boolean(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.MealGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Photo = c.String(),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        Price = c.Double(nullable: false),
                        Cuisine_Id = c.Int(),
                        Currency_Id = c.Int(),
                        MealGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cuisines", t => t.Cuisine_Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .ForeignKey("dbo.MealGroups", t => t.MealGroup_Id)
                .Index(t => t.Cuisine_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.MealGroup_Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        sing = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Photo = c.String(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Icon = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Icon = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantsGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantSchemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SmokingZone = c.Boolean(nullable: false),
                        InDoor = c.Boolean(nullable: false),
                        XLength = c.Int(nullable: false),
                        YLength = c.Int(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Seats = c.Int(nullable: false),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        RestaurantSchema_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RestaurantSchemas", t => t.RestaurantSchema_Id)
                .Index(t => t.RestaurantSchema_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Restaurant_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PriceEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Сurrency = c.String(),
                        Meal_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.Meal_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Meal_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.TableReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Reserved = c.Boolean(nullable: false),
                        ReservedAndConfirmed = c.Boolean(nullable: false),
                        Table_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tables", t => t.Table_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Table_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RestaurantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        FoodRank = c.Int(nullable: false),
                        AmbienceRank = c.Int(nullable: false),
                        ServiceRank = c.Int(nullable: false),
                        Rank = c.Double(nullable: false),
                        Restaurant_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SpecialWorkHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenHour = c.Time(nullable: false, precision: 7),
                        CloseHour = c.Time(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.WorkHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenHour = c.Time(nullable: false, precision: 7),
                        CloseHour = c.Time(nullable: false, precision: 7),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RestaurantCuisines",
                c => new
                    {
                        Restaurant_Id = c.Int(nullable: false),
                        Cuisine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_Id, t.Cuisine_Id })
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cuisines", t => t.Cuisine_Id, cascadeDelete: true)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.Cuisine_Id);
            
            CreateTable(
                "dbo.EventTypeRestaurantEvents",
                c => new
                    {
                        EventType_Id = c.Int(nullable: false),
                        RestaurantEvent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventType_Id, t.RestaurantEvent_Id })
                .ForeignKey("dbo.EventTypes", t => t.EventType_Id, cascadeDelete: true)
                .ForeignKey("dbo.RestaurantEvents", t => t.RestaurantEvent_Id, cascadeDelete: true)
                .Index(t => t.EventType_Id)
                .Index(t => t.RestaurantEvent_Id);
            
            CreateTable(
                "dbo.RestaurantFeatureRestaurants",
                c => new
                    {
                        RestaurantFeature_Id = c.Int(nullable: false),
                        Restaurant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RestaurantFeature_Id, t.Restaurant_Id })
                .ForeignKey("dbo.RestaurantFeatures", t => t.RestaurantFeature_Id, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .Index(t => t.RestaurantFeature_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.OrderTables",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Table_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Table_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tables", t => t.Table_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Table_Id);
            
            CreateTable(
                "dbo.CuisineApplicationUsers",
                c => new
                    {
                        Cuisine_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Cuisine_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Cuisines", t => t.Cuisine_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Cuisine_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Photos", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Phones", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CuisineApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CuisineApplicationUsers", "Cuisine_Id", "dbo.Cuisines");
            DropForeignKey("dbo.WorkHours", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.SpecialWorkHours", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantReviews", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RestaurantReviews", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.TableReservations", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TableReservations", "Table_Id", "dbo.Tables");
            DropForeignKey("dbo.Tables", "RestaurantSchema_Id", "dbo.RestaurantSchemas");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderTables", "Table_Id", "dbo.Tables");
            DropForeignKey("dbo.OrderTables", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.PriceEntries", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.PriceEntries", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.RestaurantSchemas", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "RestaurantGroup_Id", "dbo.RestaurantsGroups");
            DropForeignKey("dbo.RestaurantFeatureRestaurants", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantFeatureRestaurants", "RestaurantFeature_Id", "dbo.RestaurantFeatures");
            DropForeignKey("dbo.RestaurantEvents", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.EventTypeRestaurantEvents", "RestaurantEvent_Id", "dbo.RestaurantEvents");
            DropForeignKey("dbo.EventTypeRestaurantEvents", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Menus", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.MealGroups", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.Meals", "MealGroup_Id", "dbo.MealGroups");
            DropForeignKey("dbo.Meals", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Meals", "Cuisine_Id", "dbo.Cuisines");
            DropForeignKey("dbo.Restaurants", "Map_id", "dbo.Maps");
            DropForeignKey("dbo.Likes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantCuisines", "Cuisine_Id", "dbo.Cuisines");
            DropForeignKey("dbo.RestaurantCuisines", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Restaurants", "Neighborhood_Id", "dbo.Neighborhoods");
            DropForeignKey("dbo.Neighborhoods", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Restaurants", "Administration_Id", "dbo.Administrations");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Administration_Id", "dbo.Administrations");
            DropIndex("dbo.CuisineApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CuisineApplicationUsers", new[] { "Cuisine_Id" });
            DropIndex("dbo.OrderTables", new[] { "Table_Id" });
            DropIndex("dbo.OrderTables", new[] { "Order_Id" });
            DropIndex("dbo.RestaurantFeatureRestaurants", new[] { "Restaurant_Id" });
            DropIndex("dbo.RestaurantFeatureRestaurants", new[] { "RestaurantFeature_Id" });
            DropIndex("dbo.EventTypeRestaurantEvents", new[] { "RestaurantEvent_Id" });
            DropIndex("dbo.EventTypeRestaurantEvents", new[] { "EventType_Id" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Cuisine_Id" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Restaurant_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Photos", new[] { "Restaurant_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Phones", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.WorkHours", new[] { "Restaurant_Id" });
            DropIndex("dbo.SpecialWorkHours", new[] { "Restaurant_Id" });
            DropIndex("dbo.RestaurantReviews", new[] { "User_Id" });
            DropIndex("dbo.RestaurantReviews", new[] { "Restaurant_Id" });
            DropIndex("dbo.TableReservations", new[] { "User_Id" });
            DropIndex("dbo.TableReservations", new[] { "Table_Id" });
            DropIndex("dbo.PriceEntries", new[] { "Order_Id" });
            DropIndex("dbo.PriceEntries", new[] { "Meal_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Restaurant_Id" });
            DropIndex("dbo.Tables", new[] { "RestaurantSchema_Id" });
            DropIndex("dbo.RestaurantSchemas", new[] { "Restaurant_Id" });
            DropIndex("dbo.RestaurantEvents", new[] { "Restaurant_Id" });
            DropIndex("dbo.Meals", new[] { "MealGroup_Id" });
            DropIndex("dbo.Meals", new[] { "Currency_Id" });
            DropIndex("dbo.Meals", new[] { "Cuisine_Id" });
            DropIndex("dbo.MealGroups", new[] { "Menu_Id" });
            DropIndex("dbo.Menus", new[] { "Restaurant_Id" });
            DropIndex("dbo.Likes", new[] { "User_Id" });
            DropIndex("dbo.Likes", new[] { "Restaurant_Id" });
            DropIndex("dbo.Neighborhoods", new[] { "City_Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropIndex("dbo.Restaurants", new[] { "RestaurantGroup_Id" });
            DropIndex("dbo.Restaurants", new[] { "Map_id" });
            DropIndex("dbo.Restaurants", new[] { "City_Id" });
            DropIndex("dbo.Restaurants", new[] { "Neighborhood_Id" });
            DropIndex("dbo.Restaurants", new[] { "Administration_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Administration_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.CuisineApplicationUsers");
            DropTable("dbo.OrderTables");
            DropTable("dbo.RestaurantFeatureRestaurants");
            DropTable("dbo.EventTypeRestaurantEvents");
            DropTable("dbo.RestaurantCuisines");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Photos");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Phones");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.WorkHours");
            DropTable("dbo.SpecialWorkHours");
            DropTable("dbo.RestaurantReviews");
            DropTable("dbo.TableReservations");
            DropTable("dbo.PriceEntries");
            DropTable("dbo.Orders");
            DropTable("dbo.Tables");
            DropTable("dbo.RestaurantSchemas");
            DropTable("dbo.RestaurantsGroups");
            DropTable("dbo.RestaurantFeatures");
            DropTable("dbo.EventTypes");
            DropTable("dbo.RestaurantEvents");
            DropTable("dbo.Currencies");
            DropTable("dbo.Meals");
            DropTable("dbo.MealGroups");
            DropTable("dbo.Menus");
            DropTable("dbo.Maps");
            DropTable("dbo.Likes");
            DropTable("dbo.Neighborhoods");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Cuisines");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Administrations");
        }
    }
}
