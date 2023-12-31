namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "BuyerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tokens", "SellerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "SellerId", c => c.String());
            AlterColumn("dbo.Tokens", "BuyerId", c => c.String());
        }
    }
}
