namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductGaleries",
                c => new
                    {
                        GalleryID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ImageName = c.String(),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductGaleries", "ProductID", "dbo.Products");
            DropIndex("dbo.ProductGaleries", new[] { "ProductID" });
            DropTable("dbo.ProductGaleries");
        }
    }
}
