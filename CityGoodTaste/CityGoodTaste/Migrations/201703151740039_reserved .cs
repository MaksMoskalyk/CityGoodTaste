namespace CityGoodTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reserved : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tables", "Reserved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tables", "Reserved");
        }
    }
}
