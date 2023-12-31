namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        BrandDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Cart_Id = c.Int(),
                        Order_Id = c.Int(),
                        Review_Id = c.Int(),
                        Token_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Reviews", t => t.Review_Id)
                .ForeignKey("dbo.Tokens", t => t.Token_Id)
                .Index(t => t.Cart_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Review_Id)
                .Index(t => t.Token_Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                        Cart_Id = c.Int(),
                        Order_Id = c.Int(),
                        Review_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Reviews", t => t.Review_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId)
                .Index(t => t.SellerId)
                .Index(t => t.Cart_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Review_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDescription = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StoreName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                        Token_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tokens", t => t.Token_Id)
                .Index(t => t.Token_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenString = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(),
                        BuyerId = c.String(),
                        SellerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VerificationCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ExpireDate = c.DateTime(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.BuyerId)
                .Index(t => t.SellerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VerificationCodes", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.VerificationCodes", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Sellers", "Token_Id", "dbo.Tokens");
            DropForeignKey("dbo.Buyers", "Token_Id", "dbo.Tokens");
            DropForeignKey("dbo.Products", "Review_Id", "dbo.Reviews");
            DropForeignKey("dbo.Buyers", "Review_Id", "dbo.Reviews");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Buyers", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Products", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Buyers", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.VerificationCodes", new[] { "SellerId" });
            DropIndex("dbo.VerificationCodes", new[] { "BuyerId" });
            DropIndex("dbo.Sellers", new[] { "Token_Id" });
            DropIndex("dbo.Products", new[] { "Review_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            DropIndex("dbo.Products", new[] { "SellerId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Buyers", new[] { "Token_Id" });
            DropIndex("dbo.Buyers", new[] { "Review_Id" });
            DropIndex("dbo.Buyers", new[] { "Order_Id" });
            DropIndex("dbo.Buyers", new[] { "Cart_Id" });
            DropTable("dbo.VerificationCodes");
            DropTable("dbo.Tokens");
            DropTable("dbo.Reviews");
            DropTable("dbo.Orders");
            DropTable("dbo.Sellers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
            DropTable("dbo.Buyers");
            DropTable("dbo.Brands");
        }
    }
}
