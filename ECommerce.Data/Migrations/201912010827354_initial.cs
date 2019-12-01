namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        ProductGroupId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductGroupId)
                .ForeignKey("dbo.ProductGroups", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Product_ProductGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductGroupId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductTitle = c.String(nullable: false, maxLength: 350),
                        ShortDescription = c.String(nullable: false, maxLength: 500),
                        Text = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ImageName = c.String(maxLength: 50),
                        CountSale = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_ProductGroup", "ProductGroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.Product_ProductGroup", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductGroups", "ParentId", "dbo.ProductGroups");
            DropIndex("dbo.Product_ProductGroup", new[] { "ProductGroupId" });
            DropIndex("dbo.Product_ProductGroup", new[] { "ProductId" });
            DropIndex("dbo.ProductGroups", new[] { "ParentId" });
            DropTable("dbo.Products");
            DropTable("dbo.Product_ProductGroup");
            DropTable("dbo.ProductGroups");
        }
    }
}
