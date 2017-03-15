namespace CityGoodTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TableReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Restaurant_Id = c.Int(),
                        Table_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .ForeignKey("dbo.Tables", t => t.Table_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.Table_Id)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.Tables", "Reserved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tables", "Reserved", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.TableReservations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TableReservations", "Table_Id", "dbo.Tables");
            DropForeignKey("dbo.TableReservations", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.TableReservations", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TableReservations", new[] { "Table_Id" });
            DropIndex("dbo.TableReservations", new[] { "Restaurant_Id" });
            DropTable("dbo.TableReservations");
        }
    }
}
