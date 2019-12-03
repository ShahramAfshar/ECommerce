namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSlider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SlideID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ImageName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SlideID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sliders");
        }
    }
}
