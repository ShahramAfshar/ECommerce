namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "ProductId", "dbo.Products");
            DropIndex("dbo.Tags", new[] { "ProductId" });
            DropTable("dbo.Tags");
        }
    }
}
