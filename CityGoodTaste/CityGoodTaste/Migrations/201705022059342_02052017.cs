namespace CityGoodTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02052017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantEvents", "PhotoSmall", c => c.String());
            AddColumn("dbo.RestaurantEvents", "PhotoBig", c => c.String());
            DropColumn("dbo.RestaurantEvents", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RestaurantEvents", "Photo", c => c.String());
            DropColumn("dbo.RestaurantEvents", "PhotoBig");
            DropColumn("dbo.RestaurantEvents", "PhotoSmall");
        }
    }
}
