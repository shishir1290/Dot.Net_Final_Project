namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codeDb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyers", "Token_Id", c => c.Int());
            AddColumn("dbo.Sellers", "Token_Id", c => c.Int());
            CreateIndex("dbo.Buyers", "Token_Id");
            CreateIndex("dbo.Sellers", "Token_Id");
            AddForeignKey("dbo.Buyers", "Token_Id", "dbo.Tokens", "Id");
            AddForeignKey("dbo.Sellers", "Token_Id", "dbo.Tokens", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sellers", "Token_Id", "dbo.Tokens");
            DropForeignKey("dbo.Buyers", "Token_Id", "dbo.Tokens");
            DropIndex("dbo.Sellers", new[] { "Token_Id" });
            DropIndex("dbo.Buyers", new[] { "Token_Id" });
            DropColumn("dbo.Sellers", "Token_Id");
            DropColumn("dbo.Buyers", "Token_Id");
        }
    }
}
