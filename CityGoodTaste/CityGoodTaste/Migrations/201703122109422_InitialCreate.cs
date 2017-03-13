namespace CityGoodTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                        Floors = c.Int(nullable: false),
                        City_Id = c.Int(),
                        Map_id = c.Int(),
                        RestaurantGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Maps", t => t.Map_id)
                .ForeignKey("dbo.RestaurantsGroups", t => t.RestaurantGroup_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Map_id)
                .Index(t => t.RestaurantGroup_Id);
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        Price = c.Double(nullable: false),
                        Cuisine_Id = c.Int(),
                        MealGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cuisines", t => t.Cuisine_Id)
                .ForeignKey("dbo.MealGroups", t => t.MealGroup_Id)
                .Index(t => t.Cuisine_Id)
                .Index(t => t.MealGroup_Id);
            
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
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Seats = c.Int(nullable: false),
                        RestaurantSchema_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RestaurantSchemas", t => t.RestaurantSchema_Id)
                .Index(t => t.RestaurantSchema_Id);
            
            CreateTable(
                "dbo.RestaurantSchemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SmokingZone = c.Boolean(nullable: false),
                        InDoor = c.Boolean(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
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
                "dbo.RestaurantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        Restaurant_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Restaurant_Id)
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
                "dbo.RestaurantEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
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
                "dbo.ApplicationUserCuisines",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Cuisine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Cuisine_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cuisines", t => t.Cuisine_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Cuisine_Id);
            
            CreateTable(
                "dbo.TableOrders",
                c => new
                    {
                        Table_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Table_Id, t.Order_Id })
                .ForeignKey("dbo.Tables", t => t.Table_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Table_Id)
                .Index(t => t.Order_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.WorkHours", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.SpecialWorkHours", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "RestaurantGroup_Id", "dbo.RestaurantsGroups");
            DropForeignKey("dbo.RestaurantFeatureRestaurants", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantFeatureRestaurants", "RestaurantFeature_Id", "dbo.RestaurantFeatures");
            DropForeignKey("dbo.RestaurantEvents", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Photos", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "Map_id", "dbo.Maps");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RestaurantReviews", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RestaurantReviews", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Phones", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tables", "RestaurantSchema_Id", "dbo.RestaurantSchemas");
            DropForeignKey("dbo.RestaurantSchemas", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.TableOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.TableOrders", "Table_Id", "dbo.Tables");
            DropForeignKey("dbo.Orders", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.PriceEntries", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.PriceEntries", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.Menus", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.MealGroups", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.Meals", "MealGroup_Id", "dbo.MealGroups");
            DropForeignKey("dbo.Meals", "Cuisine_Id", "dbo.Cuisines");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserCuisines", "Cuisine_Id", "dbo.Cuisines");
            DropForeignKey("dbo.ApplicationUserCuisines", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantCuisines", "Cuisine_Id", "dbo.Cuisines");
            DropForeignKey("dbo.RestaurantCuisines", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.RestaurantFeatureRestaurants", new[] { "Restaurant_Id" });
            DropIndex("dbo.RestaurantFeatureRestaurants", new[] { "RestaurantFeature_Id" });
            DropIndex("dbo.TableOrders", new[] { "Order_Id" });
            DropIndex("dbo.TableOrders", new[] { "Table_Id" });
            DropIndex("dbo.ApplicationUserCuisines", new[] { "Cuisine_Id" });
            DropIndex("dbo.ApplicationUserCuisines", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Cuisine_Id" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Restaurant_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.WorkHours", new[] { "Restaurant_Id" });
            DropIndex("dbo.SpecialWorkHours", new[] { "Restaurant_Id" });
            DropIndex("dbo.RestaurantEvents", new[] { "Restaurant_Id" });
            DropIndex("dbo.Photos", new[] { "Restaurant_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.RestaurantReviews", new[] { "User_Id" });
            DropIndex("dbo.RestaurantReviews", new[] { "Restaurant_Id" });
            DropIndex("dbo.Phones", new[] { "User_Id" });
            DropIndex("dbo.RestaurantSchemas", new[] { "Restaurant_Id" });
            DropIndex("dbo.Tables", new[] { "RestaurantSchema_Id" });
            DropIndex("dbo.Menus", new[] { "Restaurant_Id" });
            DropIndex("dbo.MealGroups", new[] { "Menu_Id" });
            DropIndex("dbo.Meals", new[] { "MealGroup_Id" });
            DropIndex("dbo.Meals", new[] { "Cuisine_Id" });
            DropIndex("dbo.PriceEntries", new[] { "Order_Id" });
            DropIndex("dbo.PriceEntries", new[] { "Meal_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Restaurant_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Likes", new[] { "User_Id" });
            DropIndex("dbo.Likes", new[] { "Restaurant_Id" });
            DropIndex("dbo.Restaurants", new[] { "RestaurantGroup_Id" });
            DropIndex("dbo.Restaurants", new[] { "Map_id" });
            DropIndex("dbo.Restaurants", new[] { "City_Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropTable("dbo.RestaurantFeatureRestaurants");
            DropTable("dbo.TableOrders");
            DropTable("dbo.ApplicationUserCuisines");
            DropTable("dbo.RestaurantCuisines");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.WorkHours");
            DropTable("dbo.SpecialWorkHours");
            DropTable("dbo.RestaurantsGroups");
            DropTable("dbo.RestaurantFeatures");
            DropTable("dbo.RestaurantEvents");
            DropTable("dbo.Photos");
            DropTable("dbo.Maps");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.RestaurantReviews");
            DropTable("dbo.Phones");
            DropTable("dbo.RestaurantSchemas");
            DropTable("dbo.Tables");
            DropTable("dbo.Menus");
            DropTable("dbo.MealGroups");
            DropTable("dbo.Meals");
            DropTable("dbo.PriceEntries");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Likes");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Cuisines");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
