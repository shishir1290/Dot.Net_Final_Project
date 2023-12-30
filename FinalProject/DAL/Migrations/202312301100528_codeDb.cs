namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codeDb : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.VerificationCodes", new[] { "SellerId" });
            DropIndex("dbo.VerificationCodes", new[] { "BuyerId" });
            DropTable("dbo.VerificationCodes");
        }
    }
}
