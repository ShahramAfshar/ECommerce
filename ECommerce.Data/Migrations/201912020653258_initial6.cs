namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeatureID = c.Int(nullable: false, identity: true),
                        FeatureTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FeatureID);
            
            CreateTable(
                "dbo.Product_Feature",
                c => new
                    {
                        PF_ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        FeatureID = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PF_ID)
                .ForeignKey("dbo.Features", t => t.FeatureID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.FeatureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_Feature", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Product_Feature", "FeatureID", "dbo.Features");
            DropIndex("dbo.Product_Feature", new[] { "FeatureID" });
            DropIndex("dbo.Product_Feature", new[] { "ProductID" });
            DropTable("dbo.Product_Feature");
            DropTable("dbo.Features");
        }
    }
}
