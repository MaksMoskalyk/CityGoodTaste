namespace CityGoodTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20042017343 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TableReservations", "ConfirmedByAdministration", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TableReservations", "ConfirmedByAdministration");
        }
    }
}
