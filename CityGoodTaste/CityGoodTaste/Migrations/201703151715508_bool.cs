namespace CityGoodTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _bool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tables", "Reserved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tables", "Reserved", c => c.Boolean());
        }
    }
}
